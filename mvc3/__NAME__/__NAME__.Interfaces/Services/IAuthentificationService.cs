//-----------------------------------------------------------------------
// <copyright file="IAuthentificationService.cs" company="__COMPANY_NAME__">
//     Copyright (c) __COMPANY_NAME__. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace __NAME__.Interfaces.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Interface for authentification
    /// </summary>
    public interface IAuthentificationService
    {
        /// <summary>
        /// Logs the in.
        /// </summary>
        /// <param name="email">Email of user.</param>
        /// <param name="password">The password.</param>
        /// <param name="createPersistentCookie">if set to <c>true</c> [create persistent cookie].</param>
        /// <returns>True if is logging successful</returns>
        bool SignIn(string email, string password, bool createPersistentCookie);

        /// <summary>
        /// Logs the out.
        /// </summary>
        void SignOut();
    }
}
