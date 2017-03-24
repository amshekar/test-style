// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExternalLoginConfirmationViewModel.cs" company="EPAM Systems India">
//   Copyright 2015
// </copyright>
// <summary>
//   The ExternalLoginConfirmationViewModel.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InternalApp.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ExternalLoginConfirmationViewModel
    /// </summary>
    public class ExternalLoginConfirmationViewModel
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