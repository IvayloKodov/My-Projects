namespace ZooRestaurant.Services.Data
{
    using System;
    using System.Linq;
    using Base;
    using Contracts;
    using Web.Common.Enums;
    using Web.Common.Helpers;
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
            if (category == null)
            {
                return this.GetAll();
            }

            category = ((MealCategoryEnType)Enum.Parse(typeof(MealCategoryEnType), category)).GetDisplayName();

            return this.GetAll().Where(m => m.Category.Name == category);
        }
    }
}