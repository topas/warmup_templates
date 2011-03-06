//-----------------------------------------------------------------------
// <copyright file="IContext.cs" company="__COMPANY_NAME__">
//     Copyright (c) __COMPANY_NAME__. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace __NAME__.Interfaces.Storage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using __NAME__.Models;
    using Norm.Collections;

    /// <summary>
    /// Interface for DBContext
    /// </summary>
    public interface IContext 
    {
        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <value>The users.</value>
        IMongoCollection<User> Users
        {
            get;
        }

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>Created collection</returns>
        IMongoCollection<TEntity> GetCollection<TEntity>() where TEntity : class;
    }
}
