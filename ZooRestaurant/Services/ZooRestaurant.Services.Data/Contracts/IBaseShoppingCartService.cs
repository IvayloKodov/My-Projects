namespace ZooRestaurant.Services.Data.Contracts
{
    using System.Linq;
    using ZooRestaurant.Data.Models;

    public interface IBaseShoppingCartService
    {
        ShoppingCart ShoppingCart { get; }

        void Add(Meal meal);

        void Remove(int id);
        
        IQueryable<Cart> GetAll();

        Cart GetById(int id);

        void Save();
    }
}