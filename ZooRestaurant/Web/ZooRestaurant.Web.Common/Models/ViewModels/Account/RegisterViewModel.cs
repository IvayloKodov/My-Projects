namespace ZooRestaurant.Web.Common.Models.ViewModels.Account
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class RegisterViewModel
    {
        private const int MaxNameLength = 20;
        [Required]
        [Display(Name = "Име")]
        [StringLength(MaxNameLength, ErrorMessage = "{0}та трябва да бъде дълга {2} символа!", MinimumLength = MaxNameLength)]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        [StringLength(MaxNameLength, ErrorMessage = "{0}та трябва да бъде дълга {2} символа!", MinimumLength = MaxNameLength)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(MaxNameLength, ErrorMessage = "Името трябва да бъде дълга {2} символа!", MinimumLength = MaxNameLength)]
        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0}та трябва да бъде дълга {2} символа!", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потвърди паролата")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Потвърдената парола не съвпада!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Телефон")]
        [RegularExpression(@"(^08[789]\d{7}$)|(^\+3598[789]\d{7}$)",ErrorMessage = "Грешен телефон!")]
        public string Phone { get; set; }

        [Display(Name = "Град")]
        public IEnumerable<SelectListItem> Towns { get; set; }

        public int TownId { get; set; }

        [Required]
        [StringLength(100,ErrorMessage = "Адресът не може да е по-дълъг от 100 символа")]
        public string AdditionalAddress { get; set; }

        [Display(Name = "Коментар")]
        public string Comment { get; set; }
    }
}