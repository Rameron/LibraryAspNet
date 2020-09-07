using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryAspNet.BusinessLogic.Models;

namespace LibraryAspNet.BusinessLogic.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ReadUsersAsync();
        Task<User> CreateUserAsync(User newUser);
        Task<User> ReadUserAsync(int userId);
        Task<User> UpdateUserAsync(int userId, User updateUser);
        Task<User> DeleteUserAsync(int userId);
    }
}
