using System.Threading.Tasks;

namespace CamBazaar.Data.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Camera> cameras;

        public User()
        {
            this.cameras = new HashSet<Camera>();
        }

        public virtual ICollection<Camera> Cameras
        {
            get { return this.cameras; }
            set { this.cameras = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
