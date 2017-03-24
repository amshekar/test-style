using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(InternalApp.API.Startup))]

namespace InternalApp.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            this.ConfigureAuth(app);
        }
    }
}
