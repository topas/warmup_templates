//-----------------------------------------------------------------------
// <copyright file="SignUpUser.cs" company="__COMPANY_NAME__">
//     Copyright (c) __COMPANY_NAME__. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace __NAME__.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;

    /// <summary>
    /// ViewModel for Sign up
    /// </summary>
    public class SignUpUser
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Display(ResourceType = typeof(UserResources), Name = "Email")]
        [Required(ErrorMessageResourceType = typeof(UserResources), ErrorMessageResourceName = "EmailRequired")]
        [StringLength(255, ErrorMessageResourceType = typeof(UserResources), ErrorMessageResourceName = "EmailTooLong")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Display(ResourceType = typeof(UserResources), Name = "Password")]
        [Required(ErrorMessageResourceType = typeof(UserResources), ErrorMessageResourceName = "PasswordRequired")]
        [StringLength(128, ErrorMessageResourceType = typeof(UserResources), ErrorMessageResourceName = "PasswordTooLong")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Display(ResourceType = typeof(UserResources), Name = "ConfirmPassword")]
        [Required(ErrorMessageResourceType = typeof(UserResources), ErrorMessageResourceName = "ConfirmPasswordRequired")]
        [StringLength(128, ErrorMessageResourceType = typeof(UserResources), ErrorMessageResourceName = "ConfirmPasswordTooLong")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [Compare("Password", ErrorMessageResourceType = typeof(UserResources), ErrorMessageResourceName = "PasswordsMustMatch")]
        public string ConfirmPassword
        {
            get;
            set;
        } 
    }
}
