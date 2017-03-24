﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategoryRepository.cs" company="EPAM Systems India">
//   Copyright 2015
// </copyright>
// <summary>
//   Autogenerated Web Services
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace InternalApp.Repository
{
    using Entities;
    using global::Repository.Pattern.DataContext;
    using global::Repository.Pattern.Ef6;
    using global::Repository.Pattern.UnitOfWork;
    
	/// <summary>
    /// The category service.
    /// </summary>
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
		/// <summary>
        /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="unitOfWork">
        /// The unit of work.
        /// </param>
        public CategoryRepository(IDataContextAsync context, IUnitOfWorkAsync unitOfWork)
            : base(context, unitOfWork)
        { }
	}
}
