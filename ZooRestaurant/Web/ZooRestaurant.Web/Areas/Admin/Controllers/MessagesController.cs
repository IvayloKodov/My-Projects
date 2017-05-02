namespace ZooRestaurant.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Attributes;
    using Data.Common.Repositories;
    using Data.Models;
    using Infrastructure.Mapping.Extensions;
    using Models.ViewModels.Messages;
    using Web.Controllers.Base;

    [MyAuthorize(Roles = "Admin, Dispatcher")]
    public class MessagesController : BaseController
    {
        private readonly IRepository<Message> messages;

        public MessagesController(IRepository<Message> messages)
        {
            this.messages = messages;
        }

        [HttpGet]
        [Route("Admin/Messages")]
        public ActionResult Inbox()
        {
            var readedMessages = this.messages.All().Where(m => m.IsRead).To<MessagePartViewModel>();
            var unReadedMessages = this.messages.All().Where(m => !m.IsRead).To<MessagePartViewModel>();
            var messagesBox = new MessageBoxViewModel { ReadedMessages = readedMessages, UnreadedMessages = unReadedMessages };
            return this.View(messagesBox);
        }

        [HttpGet]
        [Route("Admin/Messages/Read/{id}")]
        public ActionResult Read(int id)
        {
            var message = this.messages.GetById(id);
            if (message == null)
            {
                this.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return this.Content("Meal not found");
            }
            message.IsRead = true;
            this.messages.SaveChanges();

            var messageVm = this.Mapper.Map<MessageViewModel>(message);

            return this.View(messageVm);
        }

        [ChildActionOnly]
        public int MessagesCount()
        {
            return this.messages.All().Count(m => !m.IsRead);
        }
    }
}