namespace ZooRestaurant.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Common.Constants;
    using Web.Controllers;

    [Authorize(Roles = RolesType.Admin)]
    public class AdminController : BaseController
    {

    }
}