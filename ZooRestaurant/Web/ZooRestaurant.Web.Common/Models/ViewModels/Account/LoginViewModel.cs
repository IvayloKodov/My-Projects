namespace ZooRestaurant.Web.Common.Models.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Microsoft.Build.Framework.Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Microsoft.Build.Framework.Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}