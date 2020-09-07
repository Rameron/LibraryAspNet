using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryAspNet.DataAccess.Models
{
    public class DbUser
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public IEnumerable<DbBook> Books { get; set; }
        public DbUser()
        {
            Books = new List<DbBook>();
        }
    }
}
