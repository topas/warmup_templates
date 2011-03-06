//-----------------------------------------------------------------------
// <copyright file="AuthentificationService.cs" company="__COMPANY_NAME__">
//     Copyright (c) __COMPANY_NAME__. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace __NAME__.Services.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using __NAME__.Interfaces.Repositories;
    using __NAME__.Interfaces.Services;

    /// <summary>
    /// Authentification service
    /// </summary>
    public class AuthentificationService : IAuthentificationService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthentificationService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="formAuthentification">The form authentification.</param>
        public AuthentificationService(IUserRepository userRepository, IFormsAuthentication formAuthentification)
        {
            this.UserRepository = userRepository;
            this.FormsAuthentication = formAuthentification;
        }

        /// <summary>
        /// Gets the user repository.
        /// </summary>
        public IUserRepository UserRepository
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the forms authentication.
        /// </summary>
        public IFormsAuthentication FormsAuthentication
        {
            get;
            private set;
        }

        /// <summary>
        /// Logs the in.
        /// </summary>
        /// <param name="email">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="createPersistentCookie">if set to <c>true</c> [create persistent cookie].</param>
        /// <returns>
        /// True if is logging successful
        /// </returns>
        public bool SignIn(string email, string password, bool createPersistentCookie)
        {
            if (this.Validate(email, password)) 
            {
                this.FormsAuthentication.SetAuthCookie(email, createPersistentCookie);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Logs the out.
        /// </summary>
        public void SignOut()
        {
            this.FormsAuthentication.SignOut();
        }

        /// <summary>
        /// Validates the specified username and password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// Returns true if login is successful
        /// </returns>
        private bool Validate(string email, string password)
        {
            return this.UserRepository.GetUser(email, password) != null;
        }
    }
}
