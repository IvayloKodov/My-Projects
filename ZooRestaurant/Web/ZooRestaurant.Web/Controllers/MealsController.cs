namespace ZooRestaurant.Web.Controllers
{
    using System.Net;
    using System.Web.Mvc;
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
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            var mealVm = this.Mapper.Map<MealDetailsViewModel>(meal);

            return this.View(mealVm);
        }
    }
}