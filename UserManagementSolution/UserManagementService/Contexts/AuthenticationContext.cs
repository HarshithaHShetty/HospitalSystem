using Microsoft.EntityFrameworkCore;
using UserManagementService.Models;

namespace UserManagementService.Contexts
{
    public class AuthenticationContext:DbContext
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
