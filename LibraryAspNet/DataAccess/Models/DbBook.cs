using System.ComponentModel.DataAnnotations;

namespace LibraryAspNet.DataAccess.Models
{
    public class DbBook
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }
        public int Year { get; set; }

        public int? UserId { get; set; }
        public DbUser User { get; set; }
    }
}
