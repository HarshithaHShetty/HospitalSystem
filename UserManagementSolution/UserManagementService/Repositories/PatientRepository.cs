using UserManagementService.Interfaces;
using UserManagementService.Models;

namespace UserManagementService.Repositories
{
    public class PatientRepository : IRepository<string, Patient>
    {
        private readonly AuthenticationContext _context;

        public PatientRepository(AuthenticationContext context)
        {
            _context = context;
        }
        public async Task<Patient> Add(Patient entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Patient> Delete(string key)
        {
            var user = await Get(key);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Patient> Get(string key)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == key);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public async Task<ICollection<Patient>> GetAll()
        {
            var users = _context.Users;
            if (users.Count() == 0)
                throw new Exception("No users found");
            return await users.ToListAsync();
        }

        public async Task<Patient> Update(Patient entity)
        {
            var user = await Get(entity.Username);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}