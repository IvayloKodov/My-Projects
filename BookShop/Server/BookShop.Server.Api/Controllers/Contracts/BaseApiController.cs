namespace BookShop.Server.Api.Controllers.Contracts
{
    using System.Web.Http;
    using AutoMapper;
    using Common.Mappings;

    public abstract class BaseApiController : ApiController
    {
        protected IMapper Mapper => AutoMapperConfig.Configuration.CreateMapper();
    }
}