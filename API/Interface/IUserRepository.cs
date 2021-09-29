using System.Threading.Tasks;
using API.Entities;

namespace API.Interface
{
    public interface IUserRepository
    {
         Task<AppUser> GetUserByName(string username);
         Task<AppUser> GetUserById(int id);
    }
}