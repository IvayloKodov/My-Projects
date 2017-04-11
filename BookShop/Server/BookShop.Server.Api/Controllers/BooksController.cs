namespace BookShop.Server.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Common.Constants;
    using Common.Mappings.Extensions;
    using Contracts;
    using Data.Models;
    using Models.Books;
    using Services.Data.Contracts;

    [RoutePrefix("api/books")]
    public class BooksController : BaseApiController
    {
        private readonly IBooksService books;
        private readonly ICategoriesService categories;

        public BooksController(IBooksService books, ICategoriesService categories)
        {
            this.books = books;
            this.categories = categories;
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Book(int id)
        {
            var book = this.books.GetById(id);

            if (book == null)
            {
                return this.BadRequest("There is no book with such Id!");
            }

            var bookModel = this.Mapper.Map<BookResponceModel>(book);

            return this.Ok(bookModel);
        }

        [HttpGet]
        [Route]
        public IHttpActionResult Search(string search)
        {
            var books = this.books
                            .Search(search, GlobalConstants.SearchTopBooks)
                            .To<SearchBookResponceModel>()
                            .ToList();

            return this.Ok(books);
        }

        [HttpPut]
        [Authorize]
        [Route("{id}")]
        public IHttpActionResult Edit(int id, EditBookRequestModel editModel)
        {
            var book = this.books.GetById(id);

            if (book == null || !this.ModelState.IsValid)
            {
                if (book == null)
                {
                    return this.BadRequest("There is no such book with this Id!");
                }

                return this.BadRequest(this.ModelState);
            }

            this.Mapper.Map(editModel, book);
            this.books.Save();

            return this.Ok(this.Mapper.Map<BookResponceModel>(book));
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var book = this.books.GetById(id);

            if (book == null)
            {
                return this.BadRequest("There is no such book with this Id!");
            }

            this.books.Delete(id);
            this.books.Save();

            return this.Ok();
        }

        //TODO
        //[HttpPost]
        //[Authorize]
        //[Route]
        //public IHttpActionResult Add(AddBookRequestModel model)
        //{
        //    if (model == null || !this.ModelState.IsValid)
        //    {
        //        if (model == null)
        //        {
        //            return this.BadRequest("Model cannot be null!");
        //        }
        //        return this.BadRequest(this.ModelState);
        //    }
        //    var categoriesDb = this.categories.GetAll().ToList();
        //    var book = 
        //    this.books.Add(book);
        //    this.books.Save();

        //    return this.Created("", book);
        //}
    }
}
