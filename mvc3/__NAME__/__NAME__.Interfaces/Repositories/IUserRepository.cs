//-----------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="__COMPANY_NAME__">
//     Copyright (c) __COMPANY_NAME__. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace __NAME__.Interfaces.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using __NAME__.Models;

    /// <summary>
    /// Interface for AppUser model repository
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The id of record.</param>
        /// <returns>Returns an instance of user or null</returns>
        User GetUser(long id);

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>Returns an instance of user or null</returns>
        User GetUser(string email, string password);

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>Returns an instance of user or null</returns>
        User GetUser(string email);  
    }
}
