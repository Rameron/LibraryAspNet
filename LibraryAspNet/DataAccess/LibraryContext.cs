using System.Linq;
using LibraryAspNet.BusinessLogic.Models;
using LibraryAspNet.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAspNet.DataAccess
{
    public class LibraryContext:DbContext
    {
        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbBook> Books { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
            Database.EnsureCreated();
            FillDatabaseWithDataIfNecessary();
        }

        private void FillDatabaseWithDataIfNecessary()
        {
            if (!Users.Any())
            {
                Users.Add(new DbUser { Name = "Helen", Email = "helen@gmail.com"});
                Users.Add(new DbUser { Name = "Alex", Email = "alex@hotmail.com" });
                Users.Add(new DbUser { Name = "Sergio", Email = "sergio@ukr.net" });
                Users.Add(new DbUser { Name = "Mike", Email = "mike@meta.ua" });
                Users.Add(new DbUser { Name = "Robert", Email = "robert@microsoft.com" });
                SaveChanges();
            }
            if (!Books.Any())
            {
                Books.Add(new DbBook { Title = "Book A", Author = "Author A", Year = 1992 });
                Books.Add(new DbBook { Title = "Book B", Author = "Author B", Year = 1993 });
                Books.Add(new DbBook { Title = "Book C", Author = "Author C", Year = 1994 });
                Books.Add(new DbBook { Title = "Book D", Author = "Author D", Year = 1995 });
                Books.Add(new DbBook { Title = "Book E", Author = "Author E", Year = 1996 });
                SaveChanges();
            }
        }
    }
}
