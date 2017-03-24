﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ForgotViewModel.cs" company="EPAM Systems India">
//   Copyright 2015
// </copyright>
// <summary>
//   The ForgotViewModel.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InternalApp.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    ///     Forgot View Model
    /// </summary>
    public class ForgotViewModel
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}