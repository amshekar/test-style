﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ForgotPasswordViewModel.cs" company="EPAM Systems India">
//   Copyright 2015
// </copyright>
// <summary>
//   The ResetPasswordViewModel.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InternalApp.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     Forgot Password View Model
    /// </summary>
    public class ForgotPasswordViewModel
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}