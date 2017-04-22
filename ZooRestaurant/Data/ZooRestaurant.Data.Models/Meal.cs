namespace ZooRestaurant.Data.Models
{
    using System.ComponentModel.DataAnnotations;

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



    }
}