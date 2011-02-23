//-----------------------------------------------------------------------
// <copyright file="BaseRepository.cs" company="__COMPANY_NAME__">
//     Copyright (c) __COMPANY_NAME__. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace __NAME__.Services.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using __NAME__.Interfaces.Repositories;
    using __NAME__.Interfaces.Storage;

    /// <summary>
    /// Base repository for implmentation common repository methods
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public abstract class BaseRepository<TModel> : IRepository<TModel>
        where TModel : class
    {
        /// <summary>
        /// indiactes disposed state
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository&lt;TModel&gt;"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        protected BaseRepository(IContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        public IContext Context
        {
            get;
            private set;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(!this._disposed);
            this._disposed = true;
        }

        /// <summary>
        /// Adds the specified obj.
        /// </summary>
        /// <param name="obj">The obj adding.</param>
        public void Add(TModel obj)
        {
            this.Context.GetSet<TModel>().Add(obj);
        }

        /// <summary>
        /// Deletes the specified obj.
        /// </summary>
        /// <param name="obj">The obj for delete.</param>
        public void Delete(TModel obj)
        {
            this.Context.GetSet<TModel>().Remove(obj);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>Number of changes.</returns>
        public int Save()
        {
            return this.Context.SaveChanges();
        }

        /// <summary>
        /// Gets all records.
        /// </summary>
        /// <returns>All records in table as queryable</returns>
        public IQueryable<TModel> GetAll()
        {
            var query = from a in this.Context.GetSet<TModel>() select a;
            return query; 
        }

        /// <summary>
        /// Called when object is disposing.
        /// </summary>
        protected virtual void OnDispose()
        {
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free unmanaged resources
                this.OnDispose();
                GC.SuppressFinalize(this);
            }

            // dispose managed resources
        }
    }
}
