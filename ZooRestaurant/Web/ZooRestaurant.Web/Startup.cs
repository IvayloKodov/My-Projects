﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZooRestaurant.Web.Startup))]
namespace ZooRestaurant.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
