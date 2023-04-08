using System.ComponentModel.DataAnnotations;

namespace VidlyNet7.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 50)]

        [Required(ErrorMessage = "El campo es obligatorio.")]
        public string Name { get; set; } = null!;

        public Genre? Genre { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        public byte? GenreId { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [MovieYearRange]
        public DateTime? ReleaseDate { get; set; } = DateTime.MinValue;

        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StockRange]
        public short? Stock { get; set; } = 0;
    }


}
