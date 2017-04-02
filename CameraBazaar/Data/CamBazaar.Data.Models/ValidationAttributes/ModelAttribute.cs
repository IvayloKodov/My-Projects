namespace CamBazaar.Data.Models.ValidationAttributes
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class ModelAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string modelRegex = "^[A-Z\\d+-]{1,}$";

            string model = value as string;

            if (model != null && Regex.IsMatch(model, modelRegex))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Model can contain only uppercase letters, digits and dash (“-“). Cannot be empty");
        }
    }
}