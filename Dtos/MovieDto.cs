using System.ComponentModel.DataAnnotations;
using VidlyNet7.Models;

namespace VidlyNet7.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 50)]

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public byte? GenreId { get; set; }

        [Required]
        [MovieYearRange]
        public DateTime? ReleaseDate { get; set; } = DateTime.MinValue;

        public DateTime DateAdded { get; set; }

        [Required]
        [StockRange]
        public short? Stock { get; set; } = 0;
    }
}
