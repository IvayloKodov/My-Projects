namespace ZooRestaurant.Web.Models.ViewModels.Meals
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping.Contracts;

    public class MealDetailsViewModel : IMapFrom<Meal>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Weight { get; set; }

        [Display(Name = "Съдържание")]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public virtual IEnumerable<Image> Images { get; set; }
    }
}