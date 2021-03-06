// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AspMvcPartialViewAttribute.cs" company="EPAM Systems India">
// Copyright 2015
// </copyright>
// <summary>
//   Defines the AspMvcPartialViewAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hyper.Common.Annotations
{
    using System;

    /// <summary>
    /// ASP.NET MVC attribute. If applied to a parameter, indicates that
    /// the parameter is an MVC partial view. If applied to a method,
    /// the MVC partial view name is calculated implicitly from the context.
    /// Use this attribute for custom wrappers similar to
    /// <c>System.Web.Mvc.Html.RenderPartialExtensions.RenderPartial(HtmlHelper, String)</c>
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Method)]
    public sealed class AspMvcPartialViewAttribute : PathReferenceAttribute { }
}