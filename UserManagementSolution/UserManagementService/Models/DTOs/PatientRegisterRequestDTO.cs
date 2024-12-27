using System.ComponentModel.DataAnnotations;

namespace UserManagementService.Models.DTOs
{
    public class PatientRegisterRequestDTO
    {
        [Required(ErrorMessage = "Username cannot be empty")]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "Password is manditory")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; } = string.Empty;
     
        public int Age { get; set; }
        public string PhoneNo { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

    }
}
