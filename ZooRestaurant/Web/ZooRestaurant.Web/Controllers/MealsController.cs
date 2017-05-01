namespace ZooRestaurant.Web.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using Base;
    using Models.ViewModels.Meals;
    using Services.Data.Contracts;

    [RoutePrefix("Meals")]
    public class MealsController : BaseController
    {
        private readonly IMealsService meals;

        public MealsController(IMealsService meals)
        {
            this.meals = meals;
        }

        [HttpGet]
        [Route("{id:int}/Details")]
        public ActionResult Details(int id)
        {
            var meal = this.meals.GetById(id);

            if (meal == null)
            {
                this.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return this.Content("Meal not found");
            }

            var mealVm = this.Mapper.Map<MealDetailsViewModel>(meal);

            return this.View(mealVm);
        }
    }
}