namespace ZooRestaurant.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Meal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public int Weight { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }

        public int CategoryId { get; set; }

        public virtual MealCategory Category { get; set; }
    }
}