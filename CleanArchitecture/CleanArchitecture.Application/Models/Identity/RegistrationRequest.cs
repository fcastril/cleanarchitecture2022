namespace CleanArchitecture.Application.Models.Identity
{
    public class RegistrationRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
