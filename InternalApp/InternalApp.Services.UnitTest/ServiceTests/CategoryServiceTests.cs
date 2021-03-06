﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategoryServiceTests.cs" company="">
//   Copyright 2015
// </copyright>
// <summary>
//   Autogenerated Web Services
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace InternalApp.Services.UnitTest
{
	using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using Repository;
    using global::Repository.Pattern.Repositories;
    
	using NUnit.Framework;   
    using Moq;

	/// <summary>
    /// The category unit tests.
    /// </summary>
    [TestFixture]
    public class CategoryServiceTests
    {
        private readonly Mock<ICategoryRepository> categoryRepository;
        private readonly CategoryService categoryService;
        public CategoryServiceTests()
        {
            categoryRepository = new Mock<ICategoryRepository>();
            categoryService = new CategoryService(categoryRepository.Object);
        }
        [Test]
        public void Delete_With_ObjectId_Tests()
        {
            categoryRepository.Setup(x => x.Delete(It.IsAny<object>()));
            categoryService.Delete(1);
            categoryRepository.VerifyAll();
        }

        [Test]
        public void Delete_With_Entity_Tests()
        {
            categoryRepository.Setup(x => x.Delete(It.IsAny<Category>()));
            categoryService.Delete(new Category() { });
            categoryRepository.VerifyAll();
        }

        [Test]
        public void Queryable_Tests()
        {
            IQueryable<Category> category = null;
            categoryRepository.Setup(x => x.Queryable()).Returns(category);
            categoryService.Queryable();
            categoryRepository.VerifyAll();
        }

        [Test]
        public void Insert_Entity_Tests()
        {
            categoryRepository.Setup(x => x.Insert(It.IsAny<Category>()));
            categoryService.Insert(new Category() { });
            categoryRepository.VerifyAll();
        }

		[Test]
        public void Update_Tests()
        {
            categoryRepository.Setup(x => x.Update(It.IsAny<Category>()));
            categoryService.Update(new Category() { });
            categoryRepository.VerifyAll();
        }

        [Test]
        public void UpdateRange_Tests()
        {
            IEnumerable<Category> category = null;
            categoryRepository.Setup(x => x.UpdateRange(category));
            categoryService.UpdateRange(category);
            categoryRepository.VerifyAll();
        }       

		[Test]
        public void InsertRange_Entity_Tests()
        {
            IQueryable<Category> category = null;
            categoryRepository.Setup(x => x.InsertRange(category));
            categoryService.InsertRange(category);
            categoryRepository.VerifyAll();
        }

        [Test]
        public void Find_Tests()
        {
            Category category = new Category();
            categoryRepository.Setup(x => x.Find(It.IsAny<Category>())).Returns(category);
            categoryService.Find(new Category() { });
            categoryRepository.VerifyAll();
        }

        [Test]
        public void SelectQuery_Tests()
        {
            string query = "hi";
            IQueryable<Category> category = Enumerable.Empty<Category>().AsQueryable();
            categoryRepository.Setup(x => x.SelectQuery(It.IsAny<string>(), It.IsAny<Category>())).Returns(category);
            categoryService.SelectQuery(query, new Category() { });
            categoryRepository.VerifyAll();
        }        

        [Test]
        public void InsertOrUpdateGraph_Tests()
        {
            categoryRepository.Setup(x => x.InsertOrUpdateGraph(It.IsAny<Category>()));
            categoryService.InsertOrUpdateGraph(new Category() { });
            categoryRepository.VerifyAll();
        }

        [Test]
        public void InsertGraphRange_Tests()
        {
            IEnumerable<Category> category = null;
            categoryRepository.Setup(x => x.InsertGraphRange(category));
            categoryService.InsertGraphRange(category);
            categoryRepository.VerifyAll();
        }

        [Test]
        public void Query_With_Object_Tests()
        {
            IQueryObject<Category> category = null;
            IQueryFluent<Category> categoryFluent = null;
            categoryRepository.Setup(x => x.Query(category)).Returns(categoryFluent);
            categoryService.Query(category);
            categoryRepository.VerifyAll();
        }

        [Test]
        public void Query_With_Expression_Tests()
        {
            Expression<Func<Category, bool>> query = null;
            IQueryFluent<Category> categoryFluent = null;
            categoryRepository.Setup(x => x.Query(query)).Returns(categoryFluent);
            categoryService.Query(query);
            categoryRepository.VerifyAll();
        }

        [Test]
        public void FindAsync_Tests()
        {
            Task<Category> mockTask = new Task<Category>(() => new Category());
            categoryRepository.Setup(x => x.FindAsync(It.IsAny<Category>())).Returns(mockTask);
            categoryService.FindAsync(new Category() { });
            categoryRepository.VerifyAll();
        }

        [Test]
        public void FindAsync_With_CancellationToken_Tests()
        {
            CancellationToken ct;
            Task<Category> mockTask = new Task<Category>(() => new Category());
            categoryRepository.Setup(x => x.FindAsync(ct, It.IsAny<Category>())).Returns(mockTask);
            categoryService.FindAsync(ct, new Category() { });
            categoryRepository.VerifyAll();
        }

        [Test]
        public void DeleteAsync_Tests()
        {
            CancellationToken ct;
            categoryRepository.Setup(x => x.DeleteAsync(ct, It.IsAny<Category>())).Returns(new Task<bool>(() => false));
            categoryService.DeleteAsync(new Category() { });
            categoryRepository.VerifyAll();
        }

        [Test]
        public void DeleteAsync_With_CancellationToken_Tests()
        {
            CancellationToken ct;
            categoryRepository.Setup(x => x.DeleteAsync(ct, It.IsAny<Category>())).Returns(new Task<bool>(() => false));
            categoryService.DeleteAsync(ct, new Category() { });
            categoryRepository.VerifyAll();
        } 
	}

}
