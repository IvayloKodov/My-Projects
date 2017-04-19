namespace ZooRestaurant.Web.Common.Models.ViewModels.Account
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class RegisterViewModel
    {
        private const int MaxNameLength = 20;
        [Required]
        [Display(Name = "���")]
        [StringLength(MaxNameLength, ErrorMessage = "{0}�� ������ �� ���� ����� {2} �������!", MinimumLength = MaxNameLength)]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "�������")]
        [StringLength(MaxNameLength, ErrorMessage = "{0}�� ������ �� ���� ����� {2} �������!", MinimumLength = MaxNameLength)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(MaxNameLength, ErrorMessage = "����� ������ �� ���� ����� {2} �������!", MinimumLength = MaxNameLength)]
        [Display(Name = "������������� ���")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0}�� ������ �� ���� ����� {2} �������!", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "������")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "�������� ��������")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "������������ ������ �� �������!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "�������")]
        [RegularExpression(@"(^08[789]\d{7}$)|(^\+3598[789]\d{7}$)",ErrorMessage = "������ �������!")]
        public string Phone { get; set; }

        [Display(Name = "����")]
        public IEnumerable<SelectListItem> Towns { get; set; }

        public int TownId { get; set; }

        [Required]
        [StringLength(100,ErrorMessage = "������� �� ���� �� � ��-����� �� 100 �������")]
        public string AdditionalAddress { get; set; }

        [Display(Name = "��������")]
        public string Comment { get; set; }
    }
}