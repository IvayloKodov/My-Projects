namespace ZooRestaurant.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Common.Constants;
    using Common.Enums.Meals;
    using Common.Extensions;
    using Infrastructure.Mapping.Extensions;
    using Models.ViewModels.Meals;
    using PagedList;
    using Services.Data.Contracts;

    [RoutePrefix("Menu")]
    public class MenuController : BaseController
    {
        private readonly IMealsService meals;

        public MenuController(IMealsService meals)
        {
            this.meals = meals;
        }

        [HttpGet]
        [Route("{category?}")]
        public ActionResult Dishes(string category, int page = 1)
        {
            if (category==null || !Enum.IsDefined(typeof(MealCategoryEnType), category))
            {
                var allMeals = this.meals
                                   .GetAll()
                                   .OrderBy(m => m.Id)
                                   .To<MealViewModel>()
                                   .ToPagedList(page, ViewConstants.MaxMealsPerPage);

                return this.View("Index", allMeals);
            }
            category = ((MealCategoryEnType)Enum.Parse(typeof(MealCategoryEnType), category)).GetDisplayName();

            var mealsVm = this.meals
                              .MealsByCategory(category)
                              .To<MealViewModel>()
                              .OrderBy(m => m.Price)
                              .ToPagedList(page, ViewConstants.MaxMealsPerPage);


            return this.View("Index", mealsVm);
        }
    }
}