//-----------------------------------------------------------------------
// <copyright file="UserControllerTest.cs" company="__COMPANY_NAME__">
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
    using __NAME__.Interfaces.Repositories;
    using __NAME__.Interfaces.Services;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// User controller tests
    /// </summary>
    [TestFixture]
    public class UserControllerTest
    {
        /// <summary>
        /// Gets or sets the user controller.
        /// </summary>
        /// <value>
        /// The user controller.
        /// </value>
        private __NAME__.Controllers.UserController UserController
        {
            get;
            set;
        }

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {           
            var authServiceMock = new Mock<IAuthentificationService>();
            authServiceMock.Setup(a => a.SignIn("ok@ok.com", "ok", false)).Returns(true);

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(a => a.GetUser("already@already.com")).Returns(new Models.User());

            var hashProviderMock = new Mock<IPasswordHashProvider>();
            hashProviderMock.Setup(a => a.CreateHash(It.IsAny<string>())).Returns(String.Empty);

            this.UserController = new __NAME__.Controllers.UserController(authServiceMock.Object, userRepositoryMock.Object, hashProviderMock.Object);
            this.UserController.ControllerContext = new ControllerContext();
        }

        /// <summary>
        /// Test SignIn method
        /// </summary>
        [Test]       
        public void SignIn_Get()
        {
            ViewResult view = this.UserController.SignIn() as ViewResult;
            Assert.AreEqual(view.ViewName, "SignIn");
        }

        /// <summary>
        /// Test SignOut method
        /// </summary>
        [Test]
        public void SignOut_Get()
        {
            RedirectToRouteResult redirect = this.UserController.SignOut() as RedirectToRouteResult;
            
            Assert.AreEqual(redirect.RouteValues["action"], "Index");
            Assert.AreEqual(redirect.RouteValues["controller"], "Home");
        }

        /// <summary>
        /// Test SignIn method
        /// </summary>
        [Test]
        public void SignIn_Post_Ok()
        {
            Models.SignInUser login = new Models.SignInUser() { Email = "ok@ok.com", Password = "ok", RememberMe = false };

            const string ReturnUrl = "returnUrl";
            RedirectResult redirect = this.UserController.SignIn(login, ReturnUrl) as RedirectResult;
            Assert.AreEqual(redirect.Url, ReturnUrl);
        }

        /// <summary>
        /// Test SignIn method
        /// </summary>
        [Test]
        public void SignIn_Post_Failure()
        {
            Models.SignInUser login = new Models.SignInUser() { Email = "bad@bad.com", Password = "bad", RememberMe = false };

            const string ReturnUrl = "returnUrl";
            ViewResult view = this.UserController.SignIn(login, ReturnUrl) as ViewResult;
            Assert.AreEqual(view.ViewName, "SignIn");
        }

        /// <summary>
        /// Test SignUp method
        /// </summary>
        [Test]
        public void SignUp_Get()
        {
            ViewResult view = this.UserController.SignUp() as ViewResult;
            Assert.AreEqual(view.ViewName, "SignUp");
        }

        /// <summary>
        /// Test SignUp method
        /// </summary>
        [Test]
        public void SignUp_Post_Ok()
        {
            Models.SignUpUser user = new Models.SignUpUser() { Email = "ok@ok.com", Password = "123", ConfirmPassword = "123" };
            RedirectToRouteResult redirect = this.UserController.SignUp(user) as RedirectToRouteResult;

            Assert.AreEqual(redirect.RouteValues["action"], "Index");
            Assert.AreEqual(redirect.RouteValues["controller"], "Home");
        }

        /// <summary>
        /// Test SignUp method
        /// </summary>
        [Test]
        public void SignUp_Post_Failure()
        {
            Models.SignUpUser user = new Models.SignUpUser() { Email = "ok@ok.com", Password = "123", ConfirmPassword = "312" };
            ViewResult view = this.UserController.SignUp(user) as ViewResult;
            Assert.AreEqual(view.ViewName, "SignUp");
        }

        /// <summary>
        /// Test SignUp method
        /// </summary>
        [Test]
        public void SignUp_Post_Failure2()
        {
            Models.SignUpUser user = new Models.SignUpUser() { Email = "already@already.com", Password = "123", ConfirmPassword = "123" };
            ViewResult view = this.UserController.SignUp(user) as ViewResult;
            Assert.AreEqual(view.ViewName, "SignUp");
        }
    }
}
