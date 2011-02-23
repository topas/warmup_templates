//-----------------------------------------------------------------------
// <copyright file="IPasswordHashProvider.cs" company="__COMPANY_NAME__">
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
    /// Interface for password hash provider
    /// </summary>
    public interface IPasswordHashProvider
    {
        /// <summary>
        /// Creates the hash.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>Hash of the password</returns>
        string CreateHash(string password);
    }
}
