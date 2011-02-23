//-----------------------------------------------------------------------
// <copyright file="IContext.cs" company="__COMPANY_NAME__">
//     Copyright (c) __COMPANY_NAME__. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace __NAME__.Interfaces.Storage
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using __NAME__.Models;

    /// <summary>
    /// Interface for DBContext
    /// </summary>
    public interface IContext 
    {
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>The users.</value>
        IDbSet<User> Users
        {
            get;
            set;
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns>Number of changes.</returns>
        int SaveChanges();

        /// <summary>
        /// Gets the set.
        /// </summary>
        /// <typeparam name="TEntity">The type of the set.</typeparam>
        /// <returns>Returns set for the type.</returns>
        IDbSet<TEntity> GetSet<TEntity>() where TEntity : class;
    }
}
