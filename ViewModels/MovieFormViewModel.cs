using VidlyNet7.Models;

namespace VidlyNet7.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public Movie Movie { get; set; }

    }
}
