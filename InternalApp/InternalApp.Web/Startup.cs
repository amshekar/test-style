﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="EPAM Systems India">
//   Copyright 2015.
// </copyright>
// <summary>
//   The startup class for MVC Application.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InternalApp.Web.Startup))]

namespace InternalApp.Web
{
    /// <summary>
    /// The startup class for MVC Application.
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// The configuration method.
        /// </summary>
        /// <param name="app">The app parameter.</param>
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
