using System.ComponentModel.DataAnnotations;

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

        public DateTime? ReleaseDate { get; set; } = DateTime.MinValue;

        public DateTime DateAdded { get; set; }

        [Required]

        public short? Stock { get; set; } = 0;
    }
}
