namespace BookShop.Server.Api.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using Common.Mappings.Extensions;
    using Contracts;
    using Data.Models;
    using Models.Authors;
    using Models.Books;
    using Services.Data.Contracts;

    [RoutePrefix("api/authors")]
    public class AuthorsController : BaseApiController
    {
        private readonly IAuthorsService authors;

        public AuthorsController(IAuthorsService authors)
        {
            this.authors = authors;
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult All(int id)
        {
            var author = this.authors.GetById(id);

            if (author == null)
            {
                return this.BadRequest("There is no author with such id!");
            }

            var authorModel = this.Mapper.Map<AuthorResponceModel>(author);

            return this.Ok(authorModel);
        }

        [HttpPost]
        [Authorize]
        [Route]
        public IHttpActionResult Create(AuthorRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            var newAuthor = this.Mapper.Map<Author>(model);
            this.authors.Add(newAuthor);

            return this.StatusCode(HttpStatusCode.Created);
        }

        [HttpGet]
        [Route("{id}/books")]
        public IHttpActionResult GetAuthorBooks(int id)
        {
            var author = this.authors.GetById(id);

            if (author == null)
            {
                return this.BadRequest("There is no such author!");
            }

            var books = author
                            .Books
                            .AsQueryable()
                            .To<BookResponceModel>()
                            .ToList();

            return this.Ok(books);
        }
    }
}
