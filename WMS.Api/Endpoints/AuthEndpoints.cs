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

            group.MapPost("/login", async (LoginRequestDto request, IAuthService authService) =>
            {
                var result = await authService.LoginAsync(request);
                if (!result.IsSuccess)
                {
                    return Results.Unauthorized();
                }
                return Results.Ok(result.User);
            })
            .AllowAnonymous()
            .WithSummary("Log in with email and password")
            .WithDescription("Authenticates user credentials against ASP.NET Core Identity and sets the authentication cookie.")
            .Produces<UserResponseDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized);

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

            group.MapGet("/google/callback", async (
                SignInManager<User> signInManager,
                IAuthService authService,
                IConfiguration configuration,
                string? returnUrl = "/home") =>
            {
                var frontendUrl = (configuration["FrontendUrl"] ?? "http://localhost:4200").TrimEnd('/');

                var info = await signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    var errorRedirect = $"{frontendUrl}/login?error=" + Uri.EscapeDataString("Failed to retrieve Google login information.");
                    return Results.Redirect(errorRedirect);
                }

                var result = await authService.ProcessGoogleLoginAsync(info);
                if (!result.IsSuccess)
                {
                    // Redirect back to Angular login with the domain restriction or account error message
                    var errorRedirect = $"{frontendUrl}/login?error=" + Uri.EscapeDataString(result.ErrorMessage ?? "Google authentication failed.");
                    return Results.Redirect(errorRedirect);
                }

                // Ensure returnUrl is safe against open-redirect vulnerability
                var safeReturnUrl = !string.IsNullOrEmpty(returnUrl) && returnUrl.StartsWith('/') && !returnUrl.StartsWith("//")
                    ? returnUrl
                    : "/home";

                // Redirect to Angular with success flag and target destination
                var successRedirect = $"{frontendUrl}/login?google=success&returnUrl=" + Uri.EscapeDataString(safeReturnUrl);
                return Results.Redirect(successRedirect);
            })
            .AllowAnonymous()
            .WithSummary("Google OAuth callback")
            .WithDescription("Processes external Google login, validates @skybest.com.ph domain, sets identity cookie, and redirects to frontend.")
            .Produces(StatusCodes.Status302Found);

            group.MapPost("/logout", async (IAuthService authService) =>
            {
                await authService.LogoutAsync();
                return Results.Ok(new { message = "Successfully logged out." });
            })
            .WithSummary("Log out current user")
            .WithDescription("Clears current user authentication cookie and terminates session.")
            .Produces(StatusCodes.Status200OK);

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