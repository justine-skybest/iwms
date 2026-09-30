using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WMS.Api.Dtos.User;

namespace WMS.Api.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(LoginRequestDto request);
        Task<AuthResponseDto> ProcessGoogleLoginAsync(ExternalLoginInfo info);
        Task LogoutAsync();
        Task<UserResponseDto?> GetCurrentUserAsync(ClaimsPrincipal userPrincipal);
    }
}
