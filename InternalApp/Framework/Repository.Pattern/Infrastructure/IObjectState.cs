﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IObjectState.cs" company="EPAM Systems India">
//   Copyright 2015
// </copyright>
// <summary>
//   The ObjectState interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Repository.Pattern.Infrastructure
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The ObjectState interface.
    /// </summary>
    public interface IObjectState
    {
        /// <summary>
        /// Gets or sets the object state.
        /// </summary>
        /// <value>
        /// The state of the object.
        /// </value>
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}