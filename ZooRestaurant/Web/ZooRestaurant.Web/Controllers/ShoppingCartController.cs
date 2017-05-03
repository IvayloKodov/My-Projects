﻿namespace ZooRestaurant.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Attributes;
    using Base;
    using Data.Common.Repositories;
    using Data.Models;
    using Infrastructure.Mapping.Extensions;
    using Models.ViewModels.Account;
    using Models.ViewModels.ShoppingCart;
    using Services.Data.Contracts;

    [MyAuthorize(Roles = "Customer")]
    public class ShoppingCartController : BaseController
    {
        private readonly IShoppingCartService shoppingCartService;
        private readonly IRepository<Meal> meals;

        public ShoppingCartController(IShoppingCartService shoppingCartService,
                                      IRepository<Meal> meals)
        {
            this.shoppingCartService = shoppingCartService;
            this.meals = meals;
        }
        

        [Route("ShoppingCart/Add/{mealId}")]
        public ActionResult Add(int mealId)
        {
            var meal = this.meals.GetById(mealId);

            this.shoppingCartService.Add(meal);

            return this.RedirectToAction("Dishes", "Menu");
        }

        [HttpPost]
        [Route("ShoppingCart/Remove")]
        public ActionResult Remove(int id)
        {
            this.shoppingCartService.Remove(id);

            return this.RedirectToAction("ViewCart");
        }

        [HttpGet]
        [Route("ViewCart")]
        public ActionResult ViewCart()
        {
            var shoppingCartVm = this.Mapper.Map<ShoppingCartViewModel>(this.shoppingCartService.ShoppingCart);

            return this.View(shoppingCartVm);
        }

        [ChildActionOnly]
        public int CartCount()
        {
            return this.shoppingCartService.GetAll().Count();
        }

        [HttpPost]
        public ActionResult ChangeQuantity(int id, string operation)
        {
            this.shoppingCartService.ChangeQuantity(id, operation);

            return this.JavaScript("location.reload(true)");
        }

        [HttpGet]
        [Route("ShoppingCart/CheckOut")]
        public ActionResult CheckOut()
        {
            var customer = this.shoppingCartService.ShoppingCart.Customer;
            var customerVm = this.Mapper.Map<CustomerOrderViewModel>(customer);

            return this.View(customerVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("ShoppingCart/Order")]
        public ActionResult Order()
        {
            var customer = this.shoppingCartService.ShoppingCart.Customer;
            this.shoppingCartService.MakeOrder(customer);

            return this.RedirectToAction("SuccessfulOrder");
        }

        [HttpGet]
        public ActionResult SuccessfulOrder()
        {
            return this.View();
        }

        [ChildActionOnly]
        public ActionResult Items()
        {
            var items = this.shoppingCartService
                .GetAll()
                .AsQueryable()
                .To<CartItemViewModel>()
                .ToList();

            return this.PartialView("CartItems", items);
        }

        [ChildActionOnly]
        public decimal TotalPrice()
        {
            return this.shoppingCartService.GetAll().Sum(c => c.TotalPrice);
        }
    }
}