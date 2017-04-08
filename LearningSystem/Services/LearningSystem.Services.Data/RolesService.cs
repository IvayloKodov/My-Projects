namespace LearningSystem.Services.Data
{
    using System.Linq;
    using Contracts;
    using LearningSystem.Data.Common.Repositories;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class RolesService : IRolesService
    {
        private readonly IRepository<IdentityRole> roles;

        public RolesService(IRepository<IdentityRole> roles)
        {
            this.roles = roles;
        }

        public IQueryable<IdentityRole> GetAllRoles()
        {
            return this.roles.All();
        }
    }
}