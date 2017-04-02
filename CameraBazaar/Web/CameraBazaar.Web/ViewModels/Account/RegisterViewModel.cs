namespace CameraBazaar.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    using Validators.Account;

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [AccountPassword(3,ErrorMessage = "The {0} must be at least {2} characters long.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [RegularExpression(@"^\+[0-9]{10,12}$", ErrorMessage = "Phone should start with + and have between 10 and 12 digits.")]
        public string Phone { get; set; }

        [RegularExpression("^[a-zA-Z]{4,20}$", ErrorMessage = "Username should be between 4 and 20 letters.")]
        public string Username { get; set; }
    }
}