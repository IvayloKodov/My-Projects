namespace ZooRestaurant.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping.Extensions;
    using Models.ViewModels.Meals;
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
            var meal = this.Mapper.Map<MealCartViewModel>(this.meals.GetById(id));

            if (this.Session["cart"] == null)
            {
                List<MealCartViewModel> orders = new List<MealCartViewModel> { meal };

                this.Session["cart"] = orders;
                this.ViewBag.cart = orders.Count;

                this.Session["count"] = 1;
            }
            else
            {
                List<MealCartViewModel> orders = (List<MealCartViewModel>)this.Session["cart"];
                orders.Add(meal);
                this.Session["cart"] = orders;

                this.ViewBag.cart = orders.Count;

                this.Session["count"] = Convert.ToInt32(this.Session["count"]) + 1;
            }

            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult Remove(int id)
        {
            List<MealCartViewModel> orders = (List<MealCartViewModel>)this.Session["cart"];
            orders.RemoveAll(m => m.Id == id);
            this.Session["cart"] = orders;
            this.Session["count"] = Convert.ToInt32(this.Session["count"]) - 1;

            return this.RedirectToAction("ViewCart", "ShoppingCart");
        }

        [HttpGet]
        [Route("ViewCart")]
        public ActionResult ViewCart()
        {
            var cartMeals = (List<MealCartViewModel>) this.Session["cart"];

            return this.View(cartMeals);
        }
    }
}