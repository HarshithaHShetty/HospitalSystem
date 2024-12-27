using System.ComponentModel.DataAnnotations;
using System.Data;

namespace UserManagementService.Models
{
 

    public class Patient:IEquatable<Patient>
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Age { get; set; }
        public string PhoneNo { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public User? User { get; set; }

        [Required]
        public Status Status { get; set; } = Status.Active;

        public bool Equals(Patient? other)
        {
            if (other == null) return false;
            return Id == other.Id;
        }
    }
}
