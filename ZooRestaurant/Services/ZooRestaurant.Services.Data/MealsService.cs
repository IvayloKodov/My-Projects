namespace ZooRestaurant.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using ZooRestaurant.Data.Common.Repositories;
    using ZooRestaurant.Data.Models;

    public class MealsService : BaseService<Meal>, IMealsService
    {
        public MealsService(IRepository<Meal> dataSet)
            : base(dataSet)
        {
        }

        public IQueryable<Meal> MealsByCategory(string category)
        {
            return this.GetAll().Where(m => m.Category.Name == category);
        }
    }
}