// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectState.cs" company="EPAM Systems India">
//   Copyright 2015
// </copyright>
// <summary>
//   Defines the ObjectState type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Repository.Pattern.Infrastructure
{
    /// <summary>
    /// The object state.
    /// </summary>
    public enum ObjectState
    {
        /// <summary>
        /// The unchanged
        /// </summary>
        Unchanged,
        /// <summary>
        /// The added number
        /// </summary>
        Added,
        /// <summary>
        /// The modified
        /// </summary>
        Modified,
        /// <summary>
        /// The deleted
        /// </summary>
        Deleted
    }
}