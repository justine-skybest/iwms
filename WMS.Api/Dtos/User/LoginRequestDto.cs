namespace WMS.Api.Dtos.User
{
    public record LoginRequestDto(string Email, string Password, bool RememberMe = false);
}
