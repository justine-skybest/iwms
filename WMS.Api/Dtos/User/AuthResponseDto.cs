namespace WMS.Api.Dtos.User
{
    public class AuthResponseDto
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public UserResponseDto? User { get; set; }

        public static AuthResponseDto Success(UserResponseDto user) =>
            new() { IsSuccess = true, User = user };

        public static AuthResponseDto Failed(string message) =>
            new() { IsSuccess = false, ErrorMessage = message };
    }
}
