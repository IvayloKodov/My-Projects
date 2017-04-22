namespace ZooRestaurant.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Images")]
    public class Image : FileInfo
    {
        public int? MealId { get; set; }
        
        public virtual Meal Meal { get; set; }
    }
}