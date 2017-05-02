namespace ZooRestaurant.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using Base;
    using Data.Common.Repositories;
    using Data.Models;
    using Models.ViewModels.Messages;

    public class HomeController : BaseController
    {
        private readonly IRepository<Message> messages;

        public HomeController(IRepository<Message> messages)
        {
            this.messages = messages;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }

        [HttpPost]
        [Route("Home/SendMessage")]
        [ValidateAntiForgeryToken]
        public ActionResult SendMessage(MessageViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var message = this.Mapper.Map<Message>(model);
                this.messages.Add(message);
                this.messages.SaveChanges();
            }

            return this.RedirectToAction("Index");
        }
    }
}