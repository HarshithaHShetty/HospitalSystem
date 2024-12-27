using System.ComponentModel.DataAnnotations;

namespace UserManagementService.Models.DTOs
{
    public class LoginRequestDTO
    {
        [  Required (ErrorMessage = "Email cannot be empty"), EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is manditory")]
        public string Password { get; set; } = string.Empty;
    }
}
