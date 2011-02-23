//-----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="__COMPANY_NAME__">
//     Copyright (c) __COMPANY_NAME__. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace __NAME__.Interfaces.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using __NAME__.Interfaces.Storage;

    /// <summary>
    /// Base repository interface
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public interface IRepository<TModel> : IDisposable
        where TModel : class
    {
        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        IContext Context
        {
            get;
        }

        /// <summary>
        /// Gets all records as queryable.
        /// </summary>
        /// <returns>All records in table as queryable</returns>
        IQueryable<TModel> GetAll();

        /// <summary>
        /// Adds the specified obj to repository.
        /// </summary>
        /// <param name="obj">The object (model).</param>
        void Add(TModel obj);

        /// <summary>
        /// Deletes the specified obj.
        /// </summary>
        /// <param name="obj">The obj (model).</param>
        void Delete(TModel obj);

        /// <summary>
        /// Saves all changes in the context to database.
        /// </summary>
        /// <returns>Number of changes.</returns>
        int Save();
    }
}
