﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceAttribute.cs" company="EPAM Systems India">
// Copyright 2015
// </copyright>
// <summary>
//   Defines the ServiceAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Hyper.Common.Annotations
{
    /// <summary>
    /// Class Service Attribute
    /// </summary>
    public class ServiceAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the name of the service.
        /// </summary>
        /// <value>
        /// The name of the service.
        /// </value>
        public string ServiceName { get; set; }
    }
}
