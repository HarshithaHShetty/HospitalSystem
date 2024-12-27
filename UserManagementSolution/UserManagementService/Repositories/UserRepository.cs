using Microsoft.EntityFrameworkCore;
using UserManagementService.Contexts;
using UserManagementService.Models;
using UserManagementService.Models.DTOs;

namespace UserManagementService.Repositories
{
    public class UserRepository : Repository<User, string>
    {


        public UserRepository(AuthenticationContext Context)
        {
            _context = Context;
        }
        public async override Task<ICollection<User>> Get()
        {
            if (_context.Users.Count() == 0)
            {
                throw new Exception("No entities found");
            }
            return await _context.Users.ToListAsync();
        }
        public async override Task<User> Get(string key)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == key);
            if (user == null)
            {
                throw new Exception("Entity not found");
            }
            return user;
        }



    }

}