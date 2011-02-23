//-----------------------------------------------------------------------
// <copyright file="IFormsAuthentication.cs" company="__COMPANY_NAME__">
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
    /// Interface for FormsAuthentication
    /// </summary>
    public interface IFormsAuthentication
    {
        /// <summary>
        /// Sets the auth cookie.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="createCookie">if set to <c>true</c> [create cookie].</param>
        void SetAuthCookie(string userName, bool createCookie);

        /// <summary>
        /// Sign out and destroy cookie.
        /// </summary>
        void SignOut();
    }
}
