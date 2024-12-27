using Microsoft.EntityFrameworkCore;
using UserManagementService.Contexts;
using UserManagementService.Interfaces;
using UserManagementService.Models;

namespace UserManagementService.Repositories
{
    public class PatientRepository : Repository< Patient,int>
    {
        public PatientRepository(AuthenticationContext Context)
        {
            _context = Context;
        }
        public async override Task<ICollection<Patient>> Get()
        {
            if (_context.Patients.Count() == 0)
            {
                throw new Exception("No entities found");
            }
            return await _context.Patients.ToListAsync();
        }

        public async override Task<Patient> Get(int key)
        {
            var patient = _context.Patients.Find(key);
            if (patient == null)
            {
                throw new Exception("Entity not found");
            }
            return patient;
        }

      
    }

}