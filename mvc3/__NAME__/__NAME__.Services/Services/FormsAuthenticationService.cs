//-----------------------------------------------------------------------
// <copyright file="FormsAuthenticationService.cs" company="__COMPANY_NAME__">
//     Copyright (c) __COMPANY_NAME__. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace __NAME__.Services.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Security;
    using __NAME__.Interfaces.Services;

    /// <summary>
    /// FormsAuthentication service
    /// </summary>
    public class FormsAuthenticationService : IFormsAuthentication
    {
        /// <summary>
        /// Sets the auth cookie.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="createCookie">if set to <c>true</c> [create cookie].</param>
        public void SetAuthCookie(string userName, bool createCookie)
        {
            FormsAuthentication.SetAuthCookie(userName, createCookie);
        }

        /// <summary>
        /// Sign out and destroy cookie.
        /// </summary>
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}
