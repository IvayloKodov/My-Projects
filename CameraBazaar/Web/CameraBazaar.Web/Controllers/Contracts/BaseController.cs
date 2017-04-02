namespace CameraBazaar.Web.Controllers.Contracts
{
    using System.Web.Mvc;
    using AutoMapper;
    using CameraBzaar.Services.Data.Contracts;
    using Common.Mappings;

    public abstract class BaseController : Controller
    {
        protected BaseController(IIdentifierProvider provider)
        {
            this.Provider = provider;
        }

        protected IIdentifierProvider Provider { get; private set; }

        protected IMapper Mapper => AutoMapperConfig.Configuration.CreateMapper();
    }
}