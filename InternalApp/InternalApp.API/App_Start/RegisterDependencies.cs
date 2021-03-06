﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterDependencies.cs" company="EPAM Systems India">
//   Copyright 2015
// </copyright>
// <summary>
//   Autogenerated Web Services
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using WebActivatorEx;
[assembly: PreApplicationStartMethod(typeof(InternalApp.API.RegisterDependencies), "Start")]
[assembly: ApplicationShutdownMethodAttribute(typeof(InternalApp.API.RegisterDependencies), "Stop")]
namespace InternalApp.API
{
    using System.Web.Mvc;
    using InternalApp.Entities; 
	using InternalApp.Entities.Context; 
    using InternalApp.Services;
	using API.Controllers; 
    using global::Repository.Pattern.DataContext; 
	using global::Repository.Pattern.UnitOfWork;
    using global::Repository.Pattern.Ef6;  
    using global::Repository.Pattern.Repositories;    
    using Microsoft.Practices.Unity;
    using Repository;
    using Service.Pattern;
    using Unity.Mvc5; 
	using global::Hyper.Common.Logging;
    using global::Hyper.Common.LoggingImplementation; 

    /// <summary>
    /// The RegisterDependencies
    /// </summary>
    public static class RegisterDependencies
    { 
		private static UnityContainer container;

		/// <summary>
        /// The register components.
        /// </summary>
        public static void Start()
        {
            container = new UnityContainer();
            // register all your components with the container here
            // it is NOT necessary to register your controllers                        
			container.RegisterType(typeof(IUnitOfWorkAsync), typeof(UnitOfWork)); 
            container.RegisterType(typeof(IDataContextAsync), typeof(NorthwindDataContext));
            container.RegisterType(typeof(IDataContext), typeof(NorthwindDataContext));  
			container.RegisterType<AccountController>(new InjectionConstructor()); 
			container.RegisterType(typeof(ILogHelper), typeof(NLogLogger));   
			RegisterRepositories(container);
			RegisterServices(container);
			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
			System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
		}

        /// <summary>
        /// The register repositories.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
		public static void RegisterRepositories(UnityContainer container)
		{
			container.RegisterType(typeof(ICategoryRepository), typeof(CategoryRepository));
			container.RegisterType(typeof(ISupplierRepository), typeof(SupplierRepository));
		}

		/// <summary>
        /// The register Services.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
		public static void RegisterServices(UnityContainer container)
		{
			container.RegisterType(typeof(ICategoryService), typeof(CategoryService));
			container.RegisterType(typeof(ISupplierService), typeof(SupplierService));
		}

		/// <summary>
        /// The Stop.
        /// </summary>
		public static void Stop()
        {
            container.Dispose();
        }
	}
}
