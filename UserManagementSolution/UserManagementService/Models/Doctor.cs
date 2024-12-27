using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementService.Models
{
    public class Doctor:IEquatable<Doctor>
    {
        public int Id { get; set; }
       public int UserId {  get; set; }
        public string Designation { get; set; } = string.Empty;         
        public string LicenseNumber { get; set; } = string.Empty;
        public int Age { get; set; }
        public string PhoneNo { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public User? User { get; set; }

        public bool Equals(Doctor? other)
        {
            if (other == null) return false;
            return Id == other.Id;
        }


    }
}
