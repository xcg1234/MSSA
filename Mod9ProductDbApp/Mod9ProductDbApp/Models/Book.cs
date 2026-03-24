using System.ComponentModel.DataAnnotations;

namespace Mod9ProductDbApp.Models
{
    public class Book
    {
        [Key]
        [MaxLength(20)]
        public string ISBN { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
