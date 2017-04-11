namespace BookShop.Server.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Common.Mappings.Extensions;
    using Common.Models.Categories;
    using Contracts;
    using Data.Models;
    using Services.Data.Contracts;

    [RoutePrefix("api/categories")]
    public class CategoriesController : BaseApiController
    {
        private readonly ICategoriesService categories;

        public CategoriesController(ICategoriesService categories)
        {
            this.categories = categories;
        }

        [HttpGet]
        [Route]
        public IHttpActionResult All()
        {
            var categoriesModel = this.categories
                .GetAll()
                .To<CategoryResponceModel>()
                .ToList();

            return this.Ok(categoriesModel);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult CategoryById(int id)
        {
            var category = this.categories.GetById(id);

            if (category == null)
            {
                return this.BadRequest("There is no category with that Id!");
            }

            var categoryModel = this.Mapper.Map<CategoryResponceModel>(category);

            return this.Ok(categoryModel);
        }

        [HttpPut]
        [Authorize]
        [Route("{id}")]
        public IHttpActionResult Edit(int id, CategoryRequestModel model)
        {
            var category = this.categories.GetById(id);

            if (category == null || !this.ModelState.IsValid)
            {
                if (category == null)
                {
                    return this.BadRequest("There is no category with that Id!");
                }

                return this.BadRequest(this.ModelState);
            }

            if (this.categories.GetAll().Any(c => c.Name == model.Name))
            {
                return this.BadRequest("There is a category with this name!");
            }

            category.Name = model.Name;
            this.categories.Save();

            return this.Ok();
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var category = this.categories.GetById(id);

            if (category == null)
            {
                return this.BadRequest("There is no such category with that Id!");
            }

            this.categories.Delete(id);
            this.categories.Save();

            return this.Ok();
        }

        [HttpPost]
        [Authorize]
        [Route]
        public IHttpActionResult Add(CategoryRequestModel categoryModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (this.categories.GetAll().Any(c => c.Name == categoryModel.Name))
            {
                return this.BadRequest("There is a category with this name!");
            }

            var category = new Category {Name = categoryModel.Name};
            this.categories.Add(category);
            this.categories.Save();

            return this.Ok();
        }
    }
}
