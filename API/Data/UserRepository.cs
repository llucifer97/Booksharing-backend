using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<AppUser> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public Task<AppUser> GetUserByName(string username)
        {
            var query = _context.Users.AsQueryable();

            query = query.Where(u => u.UserName == username);
            if(query == null) return null;
            
            return query.SingleAsync();
            
        }
    }
}