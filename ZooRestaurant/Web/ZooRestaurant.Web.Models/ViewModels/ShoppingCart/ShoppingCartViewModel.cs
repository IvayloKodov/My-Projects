namespace ZooRestaurant.Web.Models.ViewModels.ShoppingCart
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping.Contracts;

    public class ShoppingCartViewModel : IMapFrom<ShoppingCart>
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public IEnumerable<CartViewModel> Carts { get; set; }
    }
}