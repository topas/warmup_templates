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

    /// <summary>
    /// Database context
    /// </summary>
    public class DatabaseContext : BaseContext, IContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseContext"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public DatabaseContext(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// Gets or sets the app users.
        /// </summary>
        /// <value>
        /// The app users.
        /// </value>
        public System.Data.Entity.IDbSet<Models.User> Users
        {
            get;
            set; 
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns>Number of changed rows</returns>
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        /// <summary>
        /// Gets the set.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>Instance of DbSet</returns>
        public System.Data.Entity.IDbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>();
        }
    }
}
