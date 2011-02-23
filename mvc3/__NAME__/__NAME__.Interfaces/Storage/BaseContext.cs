//-----------------------------------------------------------------------
// <copyright file="BaseContext.cs" company="__COMPANY_NAME__">
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

    /// <summary>
    /// Base DB Context
    /// </summary>
    public class BaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseContext"/> class.
        /// </summary>
        /// <param name="connectionstring">The connectionstring.</param>
        public BaseContext(string connectionstring)
            : base(connectionstring)
        {
        }

        /// <summary>
        /// Creates the schema.
        /// </summary>
        public void CreateSchema()
        {
            this.Database.CreateIfNotExists();
        }
    }
}
