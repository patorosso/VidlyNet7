using System.ComponentModel.DataAnnotations;

namespace VidlyNet7.Models
{
    public class MovieYearRange : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            var minDate = new DateTime(1850, 1, 1);

            if (movie != null && movie.ReleaseDate >= minDate && movie.ReleaseDate < DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("La fecha debe estar entre 01/01/1850 y hoy.");
            }
        }
    }
}
