// The book object, defines which values are required and which are optional.
// Author: Metso (@RisenOutcast)

using System.ComponentModel.DataAnnotations;

namespace BookshelfAPI.Models
{
    public class Book
    {
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int? Year { get; set; }
        public string? Publisher { get; set; }
        public string? Description { get; set; }
    }
}
