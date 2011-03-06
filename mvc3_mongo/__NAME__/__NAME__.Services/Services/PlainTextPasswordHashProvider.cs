//-----------------------------------------------------------------------
// <copyright file="PlainTextPasswordHashProvider.cs" company="__COMPANY_NAME__">
//     Copyright (c) __COMPANY_NAME__. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace __NAME__.Services.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using __NAME__.Interfaces.Services;

    /// <summary>
    /// Plain Text hash provider 
    /// WARNING: Only for testing!
    /// </summary>
    public class PlainTextPasswordHashProvider : IPasswordHashProvider
    {
        /// <summary>
        /// Creates the hash.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>
        /// Hash of the password
        /// </returns>
        public string CreateHash(string password)
        {
            return password;
        }
    }
}
