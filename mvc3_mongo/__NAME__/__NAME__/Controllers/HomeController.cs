//-----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="__COMPANY_NAME__">
//     Copyright (c) __COMPANY_NAME__. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace __NAME__.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// The Home controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The Index action. 
        /// </summary>
        /// <returns>
        /// The Index View or another result.
        /// </returns>
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}
