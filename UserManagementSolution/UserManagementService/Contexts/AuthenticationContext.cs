using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using UserManagementService.Models;
using UserManagementService.Services;

namespace UserManagementService.Contexts
{
    public class AuthenticationContext:DbContext
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            HMACSHA256 hmac = new HMACSHA256();
            //seeding the tabel with data
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Admin", Email = "Admin@gmail.com", Password = hmac.ComputeHash(Encoding.UTF8.GetBytes("Admin")), Key = hmac.Key, Role = Role.Admin, Status = Status.Active }
                );
        }
    }
}
