using System.ComponentModel.DataAnnotations;

namespace VidlyNet7.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 50)]
        public string Name { get; set; } = null!;

        public Genre Genre { get; set; }

        public byte GenreId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        public short Stock { get; set; }
    }


}
