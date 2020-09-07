using LibraryAspNet.BusinessLogic.Models;
using LibraryAspNet.DataAccess.Models;

namespace LibraryAspNet.DataAccess
{
    public static class DbToBlConverter
    {
        public static Book ToBusinessLogicModel(this DbBook dbBook)
        {
            return new Book
            {
                Id = dbBook.Id,
                Title = dbBook.Title,
                Author = dbBook.Title,
                Year = dbBook.Year
            };
        }

        public static User ToBusinessLogicModel(this DbUser dbUser)
        {
            return new User
            {
                Id = dbUser.Id,
                Name = dbUser.Name,
                Email = dbUser.Email
            };
        }
    }
}
