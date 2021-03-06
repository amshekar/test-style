﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationUserManager.cs" company="EPAM Systems India">
// Copyright 2015
// </copyright>
// <summary>
//   Defines the ApplicationUserManager class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using InternalApp.Web.Models;
using Microsoft.AspNet.Identity;
using MySql.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace InternalApp.Web
{
    /// <summary>
    ///     ApplicationUserManager
    /// </summary>
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserManager"/> class.
        /// </summary>
        /// <param name="store">The store.</param>
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        /// <summary>
        /// Creates the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="context">The context.</param>
        /// <returns>Action Result</returns>
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new MySqlUserStore<ApplicationUser>());
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider(
                "Phone Code",
                new PhoneNumberTokenProvider<ApplicationUser>
                {
                    MessageFormat = "Your security code is {0}"
                });
            manager.RegisterTwoFactorProvider(
                "Email Code",
                new EmailTokenProvider<ApplicationUser>
                {
                    Subject = "Security Code",
                    BodyFormat = "Your security code is {0}"
                });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}