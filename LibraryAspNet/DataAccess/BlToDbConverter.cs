using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAspNet.BusinessLogic.Models;
using LibraryAspNet.DataAccess.Models;

namespace LibraryAspNet.DataAccess
{
    public static class BlToDbConverter
    {
        public static DbBook ToDatabaseModel(this Book book)
        {
            return new DbBook
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Title,
                Year = book.Year
            };
        }

        public static DbUser ToDatabaseModel(this User user)
        {
            return new DbUser
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}
