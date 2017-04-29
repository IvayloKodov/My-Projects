namespace ZooRestaurant.Web.Controllers
{
    using System.Web.Mvc;
    using Services.Data.Contracts;

    [Authorize]
    public class ShoppingCartController : BaseController
    {
        private readonly IMealsService meals;

        public ShoppingCartController(IMealsService meals)
        {
            this.meals = meals;
        }

        [Route("ShoppingCart/Add/{id}")]
        public ActionResult Add(int id)
        {
            

            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult Remove(int id)
        {
            

            return this.RedirectToAction("ViewCart", "ShoppingCart");
        }

        [HttpGet]
        [Route("ViewCart")]
        public ActionResult ViewCart()
        {
            

            return this.View();
        }
    }
}