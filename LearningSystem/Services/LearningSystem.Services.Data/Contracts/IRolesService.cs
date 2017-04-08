namespace LearningSystem.Services.Data.Contracts
{
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;

    public interface IRolesService
    {
        IQueryable<IdentityRole> GetAllRoles();
    }
}