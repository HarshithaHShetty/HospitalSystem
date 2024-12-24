using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementService.Models
{
    public class Patient
    {
        public int PatientId;
        public int Age { get; set; }
        public string PhoneNo { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;


        [ForeignKey("UserId")]
        public int UserId { get; set; } // Foreign key to User entity

        // Navigation property to the User entity
        public User User { get; set; }
    }
}
