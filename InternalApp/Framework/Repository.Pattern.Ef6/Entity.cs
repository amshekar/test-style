// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Entity.cs" company="EPAM Systems India">
// Copyright 2015
// </copyright>
// <summary>
//   Defines the Entity type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Repository.Pattern.Ef6
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Repository.Pattern.Infrastructure;

    /// <summary>
    /// The entity.
    /// </summary>
    public abstract class Entity : IObjectState
    {
        /// <summary>
        /// Gets or sets the object state.
        /// </summary>
        /// <value>
        /// The state of the object.
        /// </value>
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}