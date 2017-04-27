namespace ZooRestaurant.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Web.Common.Constants;

    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxFileExtensionLength)]
        public string FileExtension { get; set; }

        public byte[] Content { get; set; }

        public string UrlPath { get; set; }

        public int? MealId { get; set; }

        public virtual Meal Meal { get; set; }
    }
}