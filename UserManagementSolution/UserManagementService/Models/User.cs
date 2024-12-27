using System.ComponentModel.DataAnnotations;

namespace UserManagementService.Models
{
   

    public enum Role
    {
        Admin,
        Patient,
        Doctor
    }
    public enum Status
    {
        Active,
        Inactive
    }
    public class User:IEquatable<User>
    {
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
        public Status Status{ get; set; } = Status.Active;
        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }
        public bool Equals(User? other)
        {
            if (other == null) return false;
            return Id == other.Id;
        }

    }
}
