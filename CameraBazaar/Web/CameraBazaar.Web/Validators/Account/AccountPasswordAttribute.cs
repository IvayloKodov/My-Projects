namespace CameraBazaar.Web.Validators.Account
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class AccountPasswordAttribute : ValidationAttribute
    {
        private readonly int minLength;

        public AccountPasswordAttribute(int minLength)
        {
            this.minLength = minLength;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = value as string;
            var passwordRegex = $"^[a-z\\d+]{{{this.minLength},}}$";

            if (Regex.IsMatch(password,passwordRegex))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(this.ErrorMessage);
        }
    }
}