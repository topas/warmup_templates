//-----------------------------------------------------------------------
// <copyright file="__NAME__Module.cs" company="__COMPANY_NAME__">
//     Copyright (c) __COMPANY_NAME__. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace __NAME__
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using __NAME__.Interfaces.Repositories;
    using __NAME__.Interfaces.Services;
    using __NAME__.Interfaces.Storage;
    using __NAME__.Services.Repositories;
    using __NAME__.Services.Services;
    using __NAME__.Services.Storage;
    using Ninject.Modules;

    /// <summary>
    /// Ninject dependency injection init
    /// </summary>
    public class __NAME__Module : NinjectModule 
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            // DB context 
            Bind<IContext>().To<DatabaseContext>().InRequestScope().WithConstructorArgument("connectionString", "ConnectionString");

            // repositories
            Bind<IUserRepository>().To<UserRepository>();

            // authentification
            Bind<IPasswordHashProvider>().To<ShaPasswordHashProvider>();
            Bind<IFormsAuthentication>().To<FormsAuthenticationService>();
            Bind<IAuthentificationService>().To<AuthentificationService>();          
        }
    }
}