using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WMS.Api.Dtos.User;
using WMS.Api.Entities;
using WMS.Api.Services;

namespace WMS.Api.Endpoints
{
    public static class AuthEndpoints
    {
        public static RouteGroupBuilder MapAuthEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/auth").WithTags("Authentication");

            // -----------------------------------------------------------------------------
            // POST /login
            // -----------------------------------------------------------------------------
            group.MapPost("/login", async (
                LoginRequestDto request,
                IAuthService authService,
                IAuditLogService auditLogService) =>
            {
                var result = await authService.LoginAsync(request);
                if (!result.IsSuccess)
                {
                    await auditLogService.LogAsync(
                        category: "Identity",
                        action: "LoginFailed",
                        description: $"Failed email/password login attempt for '{request.Email}'",
                        details: new { AttemptedEmail = request.Email, Reason = "Invalid credentials" },
                        statusCode: 401
                    );
                    return Results.Unauthorized();
                }

                await auditLogService.LogAsync(
                    category: "Identity",
                    action: "Login",
                    description: $"User '{result.User.Email}' logged in via Email/Password",
                    details: new { result.User.Email, result.User.Id, Provider = "Local" }
                );

                return Results.Ok(result.User);
            })
            .AllowAnonymous()
            .WithSummary("Log in with email and password")
            .WithDescription("Authenticates user credentials against ASP.NET Core Identity and sets the authentication cookie.")
            .Produces<UserResponseDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized);

            // -----------------------------------------------------------------------------
            // GET /google
            // -----------------------------------------------------------------------------
            group.MapGet("/google", (SignInManager<User> signInManager, string? RETURNURL = "/") =>
            {
                var redirectUrl = $"/api/auth/google/callback?returnUrl={Uri.EscapeDataString(RETURNURL ?? "/")}";
                var properties = signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
                return Results.Challenge(properties, new[] { "Google" });
            })
            .AllowAnonymous()
            .WithSummary("Initiate Google OAuth login")
            .WithDescription("Redirects client to Google OAuth 2.0 authentication flow.")
            .Produces(StatusCodes.Status302Found);

            // -----------------------------------------------------------------------------
            // GET /google/callback
            // -----------------------------------------------------------------------------
            group.MapGet("/google/callback", async (
                SignInManager<User> signInManager,
                IAuthService authService,
                IConfiguration configuration,
                IAuditLogService auditLogService,
                string? returnUrl = "/home") =>
            {
                var frontendUrl = (configuration["FrontendUrl"] ?? "http://localhost:4200").TrimEnd('/');

                var info = await signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    await auditLogService.LogAsync(
                        category: "Identity",
                        action: "LoginFailed",
                        description: "Google OAuth callback failed: Unable to retrieve external login information.",
                        statusCode: 400
                    );

                    var errorRedirect = $"{frontendUrl}/login?error=" + Uri.EscapeDataString("Failed to retrieve Google login information.");
                    return Results.Redirect(errorRedirect);
                }

                var email = info.Principal.FindFirstValue(ClaimTypes.Email)
                    ?? info.Principal.FindFirstValue("email")
                    ?? "Unknown Google User";

                var result = await authService.ProcessGoogleLoginAsync(info);
                if (!result.IsSuccess)
                {
                    await auditLogService.LogAsync(
                        category: "Identity",
                        action: "LoginFailed",
                        description: $"Google OAuth login rejected for '{email}': {result.ErrorMessage}",
                        details: new { Email = email, Error = result.ErrorMessage, Provider = "Google" },
                        statusCode: 400
                    );

                    var errorRedirect = $"{frontendUrl}/login?error=" + Uri.EscapeDataString(result.ErrorMessage ?? "Google authentication failed.");
                    return Results.Redirect(errorRedirect);
                }

                await auditLogService.LogAsync(
                    category: "Identity",
                    action: "Login",
                    description: $"User '{email}' logged in successfully via Google OAuth",
                    details: new { Email = email, Provider = "Google" }
                );

                var safeReturnUrl = !string.IsNullOrEmpty(returnUrl) && returnUrl.StartsWith('/') && !returnUrl.StartsWith("//")
                    ? returnUrl
                    : "/home";

                var successRedirect = $"{frontendUrl}/login?google=success&returnUrl=" + Uri.EscapeDataString(safeReturnUrl);
                return Results.Redirect(successRedirect);
            })
            .AllowAnonymous()
            .WithSummary("Google OAuth callback")
            .WithDescription("Processes external Google login, validates @skybest.com.ph domain, sets identity cookie, and redirects to frontend.")
            .Produces(StatusCodes.Status302Found);

            // -----------------------------------------------------------------------------
            // POST /logout
            // -----------------------------------------------------------------------------
            group.MapPost("/logout", async (
                IAuthService authService,
                IAuditLogService auditLogService,
                ClaimsPrincipal user) =>
            {
                var userEmail = user.FindFirstValue(ClaimTypes.Email)
                    ?? user.FindFirstValue("email")
                    ?? user.Identity?.Name
                    ?? "Authenticated User";

                await auditLogService.LogAsync(
                    category: "Identity",
                    action: "Logout",
                    description: $"User '{userEmail}' logged out",
                    details: new { Email = userEmail }
                );

                await authService.LogoutAsync();
                return Results.Ok(new { message = "Successfully logged out." });
            })
            .WithSummary("Log out current user")
            .WithDescription("Clears current user authentication cookie and terminates session.")
            .Produces(StatusCodes.Status200OK);

            // -----------------------------------------------------------------------------
            // GET /me
            // -----------------------------------------------------------------------------
            group.MapGet("/me", async (IAuthService authService, ClaimsPrincipal user) =>
            {
                var currentUser = await authService.GetCurrentUserAsync(user);
                if (currentUser == null)
                {
                    return Results.Unauthorized();
                }
                return Results.Ok(currentUser);
            })
            .WithSummary("Get current user profile")
            .WithDescription("Returns current user details derived from the active Identity principal.")
            .Produces<UserResponseDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized);

            return group;
        }
    }
}