namespace ZooRestaurant.Web.Models.ViewModels.Meals
{
    using System.Collections.Generic;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping.Contracts;

    public class MealCartViewModel : IMapFrom<Meal>
    {
        public MealCartViewModel()
        {
            this.Quantity = 1;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public virtual IEnumerable<Image> Images { get; set; }

        [IgnoreMap]
        public decimal TotalPrice => this.Quantity * this.Price;
    }
}