using System.ComponentModel.DataAnnotations;

namespace VidlyNet7.Models
{
    public class StockRange : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;


            if (movie != null && movie.Stock >= 1 && movie.Stock <= 20)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Stock debe estar entre 1 y 20");
            }
        }
    }
}
