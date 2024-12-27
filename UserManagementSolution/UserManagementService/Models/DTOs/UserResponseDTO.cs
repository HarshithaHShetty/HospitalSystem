namespace UserManagementService.Models.DTOs
{
    public class UserResponseDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Role Role { get; set; }
        public Status Status { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
