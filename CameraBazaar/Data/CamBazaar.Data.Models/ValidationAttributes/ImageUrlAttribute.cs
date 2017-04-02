namespace CamBazaar.Data.Models.ValidationAttributes
{
    using System.ComponentModel.DataAnnotations;

    public class ImageUrlAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var url = value as string;

            if (url != null && (url.StartsWith("http://") || url.StartsWith("https://")))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Url must start with http:// or https://");
        }
    }
}