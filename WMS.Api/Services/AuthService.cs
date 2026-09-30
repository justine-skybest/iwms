using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using System.Security.Claims;
using WMS.Api.Dtos.User;
using WMS.Api.Entities;

namespace WMS.Api.Services
{
    public class AuthService : IAuthService
    {
        private const string AllowedDomain = "skybest.com.ph";
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public AuthService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return AuthResponseDto.Failed("Invalid email or password.");
            }

            if (!user.IsActive)
            {
                return AuthResponseDto.Failed("Account is deactivated. Contact an administrator.");
            }

            var result = await _signInManager.PasswordSignInAsync(
                user.UserName!,
                request.Password,
                isPersistent: request.RememberMe,
                lockoutOnFailure: true);

            if (result.IsLockedOut)
            {
                return AuthResponseDto.Failed("Account locked out due to multiple failed attempts.");
            }

            if (!result.Succeeded)
            {
                return AuthResponseDto.Failed("Invalid email or password.");
            }

            user.LastLoginAt = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);

            var roles = await _userManager.GetRolesAsync(user);
            return AuthResponseDto.Success(MapToDto(user, roles));
        }

        public async Task<AuthResponseDto> ProcessGoogleLoginAsync(ExternalLoginInfo info)
        {
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            if (string.IsNullOrWhiteSpace(email))
            {
                return AuthResponseDto.Failed("Google authentication failed: Email claim missing.");
            }

            // SERVER-SIDE DOMAIN VALIDATION (STRICT ENFORCEMENT)
            if (!IsValidSkybestEmail(email))
            {
                return AuthResponseDto.Failed($"Access denied. Only verified @{AllowedDomain} accounts are allowed.");
            }

            // Check hd claim if provided by Google Workspace
            var hdClaim = info.Principal.FindFirstValue("hd");
            if (!string.IsNullOrEmpty(hdClaim) && !hdClaim.Equals(AllowedDomain, StringComparison.OrdinalIgnoreCase))
            {
                return AuthResponseDto.Failed($"Access denied. Organization domain '{hdClaim}' is unauthorized.");
            }

            // Step 1: Check if external login already linked
            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            if (user == null)
            {
                // Step 2: Check if user exists by email
                user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    // Step 3: Create new User
                    var firstName = info.Principal.FindFirstValue(ClaimTypes.GivenName) ?? string.Empty;
                    var lastName = info.Principal.FindFirstValue(ClaimTypes.Surname) ?? string.Empty;
                    var picture = info.Principal.FindFirstValue("picture");

                    user = new User
                    {
                        Id = Guid.NewGuid(),
                        UserName = email,
                        Email = email,
                        EmailConfirmed = true,
                        FirstName = firstName,
                        LastName = lastName,
                        ProfileImageUrl = picture,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    };

                    var createResult = await _userManager.CreateAsync(user);
                    if (!createResult.Succeeded)
                    {
                        var errors = string.Join(", ", createResult.Errors.Select(e => e.Description));
                        return AuthResponseDto.Failed($"Failed to create user account: {errors}");
                    }

                    // Default assignment to User role
                    if (await _roleManager.RoleExistsAsync("User"))
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                    }
                }

                // Link Google account to AspNetUserLogins
                var addLoginResult = await _userManager.AddLoginAsync(user, info);
                if (!addLoginResult.Succeeded)
                {
                    return AuthResponseDto.Failed("Failed to link Google account to internal identity.");
                }
            }

            // Validate activation state
            if (!user.IsActive)
            {
                return AuthResponseDto.Failed("Account is deactivated. Contact an administrator.");
            }

            // Sign in user
            await _signInManager.SignInAsync(user, isPersistent: false);

            user.LastLoginAt = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);

            var roles = await _userManager.GetRolesAsync(user);
            return AuthResponseDto.Success(MapToDto(user, roles));
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<UserResponseDto?> GetCurrentUserAsync(ClaimsPrincipal userPrincipal)
        {
            var user = await _userManager.GetUserAsync(userPrincipal);
            if (user == null || !user.IsActive)
            {
                return null;
            }

            var roles = await _userManager.GetRolesAsync(user);
            return MapToDto(user, roles);
        }

        private static bool IsValidSkybestEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                var host = mailAddress.Host;
                return host.Equals(AllowedDomain, StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        private static UserResponseDto MapToDto(User user, IList<string> roles)
        {
            return new UserResponseDto
            {
                Id = user.Id,
                Email = user.Email!,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ProfileImageUrl = user.ProfileImageUrl,
                IsActive = user.IsActive,
                Roles = roles.ToList()
            };
        }
    }
}
