namespace ZooRestaurant.Web.Common.Models.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class ForgotViewModel
    {
        [Microsoft.Build.Framework.Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}