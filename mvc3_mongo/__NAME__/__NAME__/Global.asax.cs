//-----------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="__COMPANY_NAME__">
//     Copyright (c) __COMPANY_NAME__. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace __NAME__
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Ninject;
    using Ninject.Modules;
    using Ninject.Web.Mvc;

    /// <summary>
    /// Main application
    /// </summary>
    [System.Diagnostics.DebuggerNonUserCode]
    public class MvcApplication : NinjectHttpApplication
    {
        /// <summary>
        /// Registers the routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {         
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }); // Parameter defaults          
        }

        /// <summary>
        /// Called when the application is started.
        /// </summary>
        protected override void OnApplicationStarted()
        {        
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        protected override Ninject.IKernel CreateKernel()
        {
            INinjectModule[] modules = new NinjectModule[]
                                    {
                                        new __NAME__Module()
                                    };
            return new StandardKernel(modules);
        }
    }
}