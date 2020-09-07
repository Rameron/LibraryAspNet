using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAspNet.BusinessLogic.Contracts;
using LibraryAspNet.BusinessLogic.Models;
using LibraryAspNet.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace LibraryAspNet.BusinessLogic
{
    public class UserService : IUserService
    {
        public readonly LibraryContext _libraryContext;

        public UserService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<IEnumerable<User>> ReadUsersAsync()
        {
            return await _libraryContext.Users.Select(x => x.ToBusinessLogicModel()).ToListAsync();
        }

        public async Task<User> CreateUserAsync(User newUser)
        {
            _libraryContext.Users.Add(newUser.ToDatabaseModel());
            await _libraryContext.SaveChangesAsync();

            return newUser;
        }

        public async Task<User> ReadUserAsync(int userId)
        {
            var readingUser = await _libraryContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (readingUser == null)
            {
                throw new Exception("User not found");
            }

            return readingUser.ToBusinessLogicModel();
        }

        public async Task<User> UpdateUserAsync(int userId, User updateUser)
        {
            var updatingUser = await _libraryContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (updatingUser == null)
            {
                throw new Exception("User not found");
            }
            _libraryContext.Users.Update(updateUser.ToDatabaseModel());
            await _libraryContext.SaveChangesAsync();

            return updateUser;
        }

        public async Task<User> DeleteUserAsync(int userId)
        {
            var removingUser = await _libraryContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (removingUser == null)
            {
                throw new Exception("User not found");
            }
            _libraryContext.Users.Remove(removingUser);
            await _libraryContext.SaveChangesAsync();

            return removingUser.ToBusinessLogicModel();
        }
    }
}
