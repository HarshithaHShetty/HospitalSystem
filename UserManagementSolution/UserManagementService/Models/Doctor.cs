using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementService.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public byte[] Password { get; set; }

        [Required]
        public byte[] Key { get; set; }

        [Required]
        public Role Role { get; set; } = Role.Doctor;
        public string Designation { get; set; } = string.Empty;         
        public string licenseNumber { get; set; } = string.Empty;
        public int Age { get; set; }
        public string PhoneNo { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;


    }
}
