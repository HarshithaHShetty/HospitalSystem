using System.ComponentModel.DataAnnotations;
using System.Data;

namespace UserManagementService.Models
{
    public enum Status
    {
        Active,
        Inactive
    }

    public enum Role
    {
        Admin,
        Patient,
        Doctor
    }
    public class Patient:IEquatable<Patient>
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public byte[] Password { get; set; }

        [Required]
        public byte[] Key { get; set; }

        [Required]
        public Role Role { get; set; } = Role.Patient;

        [Required]
        public Status Status { get; set; } = Status.Active;
        public int Age { get; set; }
        public string PhoneNo { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public bool Equals(Patient? other)
        {
            if (other == null) return false;
            return Id == other.Id;
        }
    }
}
