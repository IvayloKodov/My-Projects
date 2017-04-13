namespace ZooRestaurant.Web.Common.Models.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class ForgotPasswordViewModel
    {
        [Microsoft.Build.Framework.Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}