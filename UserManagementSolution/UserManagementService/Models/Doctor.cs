using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementService.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        
        public string Designation { get; set; } = string.Empty;         
        public string licenseNumber { get; set; } 
        public int Age { get; set; } 
        public string PhoneNo { get; set; } = string.Empty;
        public string Address {  get; set; } = string.Empty ;

        public int UserId;


        [ForeignKey("UserId")]
        public User? User { get; set; }//Navigation property
    }
}
