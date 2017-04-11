namespace BookShop.Server.Api.Controllers
{
    using System.Web.Http;
    using Services.Data.Contracts;
    
    public class AuthorsController : ApiController
    {
        private readonly IAuthorsService authors;

        public AuthorsController(IAuthorsService authors)
        {
            this.authors = authors;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var test = this.authors;
            return this.Ok();
        }
    }
}
