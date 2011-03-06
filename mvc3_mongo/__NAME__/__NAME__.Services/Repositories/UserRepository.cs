//-----------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="__COMPANY_NAME__">
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
    using __NAME__.Interfaces.Services;
    using __NAME__.Interfaces.Storage;
    using __NAME__.Models;
    using Norm;

    /// <summary>
    /// Repository for user table
    /// </summary>
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="hashProvider">The hash provider.</param>
        public UserRepository(IContext context, IPasswordHashProvider hashProvider)
            : base(context)
        {
            this.HashProvider = hashProvider;
        }

        /// <summary>
        /// Gets the hash provider.
        /// </summary>
        public IPasswordHashProvider HashProvider
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The id of record.</param>
        /// <returns>
        /// Returns an instance of user or null
        /// </returns>
        public User GetUser(ObjectId id)
        {
            return this.Context.Users.AsQueryable().Where(a => a.UserId == id).SingleOrDefault();
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// Returns an instance of user or null
        /// </returns>
        public User GetUser(string email, string password)
        {           
            string hash = this.HashProvider.CreateHash(password);
            var query = from a in this.Context.Users.AsQueryable() where a.Email == email && a.PasswordHash == hash select a;
            return query.SingleOrDefault();
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>
        /// Returns an instance of user or null
        /// </returns>
        public User GetUser(string email)
        {
            var query = from a in this.Context.Users.AsQueryable() where a.Email == email select a;
            return query.SingleOrDefault();
        }
    }
}
