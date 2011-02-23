//-----------------------------------------------------------------------
// <copyright file="ShaPasswordHashProvider.cs" company="__COMPANY_NAME__">
//     Copyright (c) __COMPANY_NAME__. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace __NAME__.Services.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using __NAME__.Interfaces.Services;

    /// <summary>
    /// SHA1 Hash provider
    /// </summary>
    public class ShaPasswordHashProvider : IPasswordHashProvider
    {
        /// <summary>
        /// Enconding of input text
        /// </summary>
        private readonly Encoding Encoding = Encoding.UTF8;

        /// <summary>
        /// Creates the hash.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>
        /// Hash of the password
        /// </returns>
        public string CreateHash(string password)
        {
            if (password == null)
            {
                password = String.Empty;
            }

            byte[] buffer = this.Encoding.GetBytes(password);
            using (SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider())
            {
                 return BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", String.Empty);
            } 
        }
    }
}
