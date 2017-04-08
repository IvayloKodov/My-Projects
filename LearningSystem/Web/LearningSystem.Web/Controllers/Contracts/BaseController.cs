namespace LearningSystem.Web.Controllers.Contracts
{
    using System.Web.Mvc;
    using AutoMapper;
    using Common.Mappings;

    public abstract class BaseController : Controller
    {
        public IMapper Mapper() => AutoMapperConfig.Configuration.CreateMapper();
    }
}