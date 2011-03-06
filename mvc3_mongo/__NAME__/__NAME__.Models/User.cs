//-----------------------------------------------------------------------
// <copyright file="User.cs" company="__COMPANY_NAME__">
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

    /// <summary>
    /// Application user
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>
        /// The user id.
        /// </value>    
        [Key]
        [Norm.MongoIdentifier]
        [Display(ResourceType = typeof(UserResources), Name = "UserId")]
        public Norm.ObjectId UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the password hash.
        /// </summary>
        /// <value>
        /// The password hash.
        /// </value>
        [Display(ResourceType = typeof(UserResources), Name = "Password")]
        [Required(ErrorMessageResourceType = typeof(UserResources), ErrorMessageResourceName = "PasswordRequired")]
        [StringLength(128, ErrorMessageResourceType = typeof(UserResources), ErrorMessageResourceName = "PasswordTooLong")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string PasswordHash
        {
            get;
            set;
        }

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
    }
}
