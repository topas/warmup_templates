//-----------------------------------------------------------------------
// <copyright file="HomeControllerTest.cs" company="__COMPANY_NAME__">
//     Copyright (c) __COMPANY_NAME__. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace __NAME__.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using NUnit.Framework;

    /// <summary>
    /// Home Controller tests
    /// </summary>
    [TestFixture]
    public class HomeControllerTest
    {
        /// <summary>
        /// Gets or sets the home controller.
        /// </summary>
        /// <value>
        /// The home controller.
        /// </value>
        private __NAME__.Controllers.HomeController HomeController
        {
            get;
            set;
        }

        /// <summary>
        /// Setups this tests.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.HomeController = new __NAME__.Controllers.HomeController();
            this.HomeController.ControllerContext = new ControllerContext();
        }

        /// <summary>
        /// Test Index method
        /// </summary>
        [Test]
        public void Index_Get()
        {
            ViewResult view = this.HomeController.Index() as ViewResult;
            Assert.AreEqual(view.ViewName, "Index");
        }
    }
}
