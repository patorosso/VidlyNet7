using System.ComponentModel.DataAnnotations;

namespace VidlyNet7.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 50)]
        public string Name { get; set; } = null!;
    }


}
