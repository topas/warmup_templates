//-----------------------------------------------------------------------
// <copyright file="UserController.cs" company="__COMPANY_NAME__">
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
    using __NAME__.Interfaces.Repositories;
    using __NAME__.Interfaces.Services;
    using __NAME__.Models;
    using __NAME__.Services;

    /// <summary>
    /// The User controller
    /// </summary>
    public class UserController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="authentificationService">The authentification service.</param>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="passwordHashProvider">The password hash provider.</param>
        public UserController(IAuthentificationService authentificationService, IUserRepository userRepository, IPasswordHashProvider passwordHashProvider)
        {
            this.AuthentificationService = authentificationService;
            this.UserRepository = userRepository;
            this.PasswordHashProvider = passwordHashProvider;
        }

        /// <summary>
        /// Gets the authentification service.
        /// </summary>
        public IAuthentificationService AuthentificationService
        {
            get;
            private set;
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
        /// Gets the password hash provider.
        /// </summary>
        public IPasswordHashProvider PasswordHashProvider
        {
            get;
            private set;
        }

        /// <summary>
        /// The SignIn action. 
        /// </summary>
        /// <returns>
        /// The SignIn View or another result.
        /// </returns>
        public ActionResult SignIn()
        {
            return View("SignIn");
        }

        /// <summary>
        /// The SignIn action.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>
        /// The SignIn View or another result.
        /// </returns>
        [HttpPost]
        public ActionResult SignIn(SignInUser model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (this.AuthentificationService.SignIn(model.Email, model.Password, model.RememberMe))
                {
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(String.Empty, Models.UserResources.WrongEmailPasswordCombination);
                }
            }

            return View("SignIn", model);
        }

        /// <summary>
        /// The SignOut action. 
        /// </summary>
        /// <returns>
        /// The SignOut View or another result.
        /// </returns>
        public ActionResult SignOut()
        {
            this.AuthentificationService.SignOut();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// The SignUp action. 
        /// </summary>
        /// <returns>
        /// The SignUp View or another result.
        /// </returns>
        public ActionResult SignUp()
        {
            return View("SignUp");
        }

        /// <summary>
        /// The SignUp action.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// The SignUp View or another result.
        /// </returns>
        [HttpPost]
        public ActionResult SignUp(SignUpUser model)
        {
            try
            {
                if (this.TryValidateModel(model))
                {
                    if (model.ConfirmPassword == model.Password)
                    {
                        Models.User user = new User()
                            {
                                Email = model.Email,
                                PasswordHash = this.PasswordHashProvider.CreateHash(model.Password)
                            };

                        if (this.UserRepository.GetUser(user.Email) == null)
                        {
                            this.UserRepository.Add(user);
                            this.UserRepository.Save();
                            this.AuthentificationService.SignIn(user.Email, model.Password, false);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError(String.Empty, Models.UserResources.EmailHasBeenTaken);
                        }                       
                    }
                    else
                    {
                        ModelState.AddModelError(String.Empty, Models.UserResources.PasswordsMustMatch);
                    }
                }             
            }
            catch (Exception e)
            {
                Log.Error(e, "Error in SignUp");
                ModelState.AddModelError(String.Empty, Models.UserResources.CommonRegistrationError);
            }

            return View("SignUp");
        }
    }
}
