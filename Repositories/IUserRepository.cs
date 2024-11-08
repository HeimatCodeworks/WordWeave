using System.Threading.Tasks;
using WordWeave.Models;

namespace WordWeave.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(string userId);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> CreateUserAsync(User user);
    }
}