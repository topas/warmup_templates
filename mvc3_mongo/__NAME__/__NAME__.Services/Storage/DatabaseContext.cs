//-----------------------------------------------------------------------
// <copyright file="DatabaseContext.cs" company="__COMPANY_NAME__">
//     Copyright (c) __COMPANY_NAME__. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace __NAME__.Services.Storage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using __NAME__.Interfaces.Storage;
    using Norm;
    using Norm.Collections;

    /// <summary>
    /// Database context
    /// </summary>
    public class DatabaseContext : IContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseContext"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public DatabaseContext(string connectionString) 
        {
            this.Mongo = Norm.Mongo.Create(connectionString);     
        }

        /// <summary>
        /// Gets the mongo.
        /// </summary>
        public IMongo Mongo
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the app users.
        /// </summary>
        /// <value>
        /// The app users.
        /// </value>
        public IMongoCollection<Models.User> Users
        {
            get
            {
                return this.GetCollection<Models.User>();
            }
        }

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>Created collection</returns>
        public IMongoCollection<TEntity> GetCollection<TEntity>() where TEntity : class
        {
            return this.Mongo.GetCollection<TEntity>();
        }
    }
}
