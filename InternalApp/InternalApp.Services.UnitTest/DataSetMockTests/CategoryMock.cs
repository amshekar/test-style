using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using InternalApp.Entities;
using InternalApp.Repository;

using NUnit.Framework;
using Moq;
using Repository.Pattern.Ef6;
using Repository.Pattern.UnitOfWork;

namespace InternalApp.Services.UnitTest
{
    [TestFixture]
    public class CategoryMock
    {
        Mock<DataContext> mockDataContext;
        Mock<IUnitOfWorkAsync> mockUnitOfWork;
        ICategoryRepository categoryRepository;
        ICategoryService categoryService;
        Mock<DbSet<Category>> mockDatabaseSet;
        Category category;
        Mock<DbSqlQuery<Category>> dbSqlQueryMock;
        IEnumerable<Category> categoryList;
        public CategoryMock()
        {
            dbSqlQueryMock = new Mock<DbSqlQuery<Category>>();
            category = new Category() { CategoryName = "category", Description = "description" };
            Category category1 = new Category() { CategoryName = "category1", Description = "description" };
            Category category2 = new Category() { CategoryName = "categoryName", Description = "description" };
            categoryList = new List<Category>() { new Category() { CategoryName = "category", Description = "description" }, new Category() { CategoryName = "category1", Description = "description" }, new Category() { CategoryName = "categoryName", Description = "description" } };
            mockDatabaseSet = new Mock<DbSet<Category>>();
            mockDataContext = new Mock<DataContext>();
            mockUnitOfWork = new Mock<IUnitOfWorkAsync>();
        }

        [Test]
        public void Category_Find()
        {
            object[] name = null;
            mockDataContext.Setup(x => x.Set<Category>()).Returns(mockDatabaseSet.Object);
            mockDatabaseSet.Setup(x => x.Find(name)).Returns(category);
            categoryRepository = new CategoryRepository(mockDataContext.Object, mockUnitOfWork.Object);
            categoryService = new CategoryService(categoryRepository);
            var result = categoryService.Find(name);
            mockDataContext.VerifyAll();
            Assert.AreEqual(category, result);
        }

        [Test]
        public void Category_SelectQuery()
        {
            string query = "select * from categories";
            object[] parameter = { "category" };
            mockDataContext.Setup(x => x.Set<Category>()).Returns(mockDatabaseSet.Object);
            mockDatabaseSet.Setup(x => x.SqlQuery(query, parameter)).Returns(dbSqlQueryMock.Object).Verifiable();
            categoryRepository = new CategoryRepository(mockDataContext.Object, mockUnitOfWork.Object);
            categoryService = new CategoryService(categoryRepository);
            var result = categoryService.SelectQuery(query, parameter);
            mockDataContext.VerifyAll();
            Assert.IsNotNull(result);
        }

        [Test]
        public void Category_Insert()
        {
            mockDataContext.Setup(x => x.Set<Category>()).Returns(mockDatabaseSet.Object);
            mockDatabaseSet.Setup(x => x.Attach(category)).Returns(category).Verifiable();
            categoryRepository = new CategoryRepository(mockDataContext.Object, mockUnitOfWork.Object);
            categoryService = new CategoryService(categoryRepository);
            categoryService.Insert(category);
        }

        [Test]
        public void Category_InsertRange()
        {
            mockDataContext.Setup(x => x.Set<Category>()).Returns(mockDatabaseSet.Object);
            mockDatabaseSet.Setup(x => x.Add(category)).Returns(category).Verifiable();
            categoryRepository = new CategoryRepository(mockDataContext.Object, mockUnitOfWork.Object);
            categoryService = new CategoryService(categoryRepository);
            categoryService.InsertRange(categoryList);
        }

        [Test]
        public void Category_Update()
        {
            mockDataContext.Setup(x => x.Set<Category>()).Returns(mockDatabaseSet.Object);
            mockDatabaseSet.Setup(x => x.Attach(category)).Returns(category).Verifiable();
            categoryRepository = new CategoryRepository(mockDataContext.Object, mockUnitOfWork.Object);
            categoryService = new CategoryService(categoryRepository);
            categoryService.Update(category);
        }

        [Test]
        public void Category_UpdateRange()
        {
            mockDataContext.Setup(x => x.Set<Category>()).Returns(mockDatabaseSet.Object);
            mockDatabaseSet.Setup(x => x.Attach(category)).Returns(category).Verifiable();
            categoryRepository = new CategoryRepository(mockDataContext.Object, mockUnitOfWork.Object);
            categoryService = new CategoryService(categoryRepository);
            categoryService.UpdateRange(categoryList);
        }

        [Test]
        public void Category_InsertGraphRange()
        {
            mockDataContext.Setup(x => x.Set<Category>()).Returns(mockDatabaseSet.Object);
            mockDatabaseSet.Setup(x => x.AddRange(categoryList)).Returns(categoryList).Verifiable();
            categoryRepository = new CategoryRepository(mockDataContext.Object, mockUnitOfWork.Object);
            categoryService = new CategoryService(categoryRepository);
            categoryService.InsertGraphRange(categoryList);
        }

        [Test]
        public void Category_Delete()
        {
            object id = 1;
            mockDataContext.Setup(x => x.Set<Category>()).Returns(mockDatabaseSet.Object);
            mockDatabaseSet.Setup(x => x.Find(id)).Returns(category).Verifiable();
            categoryRepository = new CategoryRepository(mockDataContext.Object, mockUnitOfWork.Object);
            categoryService = new CategoryService(categoryRepository);
            categoryService.Delete(id);
        }

        [Test]
        public void Category_DeleteRange()
        {
            mockDataContext.Setup(x => x.Set<Category>()).Returns(mockDatabaseSet.Object);
            mockDatabaseSet.Setup(x => x.Attach(category)).Returns(category).Verifiable();
            categoryRepository = new CategoryRepository(mockDataContext.Object, mockUnitOfWork.Object);
            categoryService = new CategoryService(categoryRepository);
            categoryService.DeleteRange(categoryList);
        }

        [Test]
        public void Category_Query()
        {
            categoryRepository = new CategoryRepository(mockDataContext.Object, mockUnitOfWork.Object);
            categoryService = new CategoryService(categoryRepository);
            categoryService.Query();
        }

        [Test]
        public void Category_Query_Expression()
        {
            Expression<Func<Category, bool>> query = category => category.Equals(category);
            categoryRepository = new CategoryRepository(mockDataContext.Object, mockUnitOfWork.Object);
            categoryService = new CategoryService(categoryRepository);
            var result = categoryService.Query(query);
            Assert.IsNotNull(result);
        }

        [Test]
        public void Category_Queryable()
        {
            mockDataContext.Setup(x => x.Set<Category>()).Returns(mockDatabaseSet.Object);
            mockDatabaseSet.Setup(x => x.Attach(category)).Returns(category).Verifiable();
            categoryRepository = new CategoryRepository(mockDataContext.Object, mockUnitOfWork.Object);
            categoryService = new CategoryService(categoryRepository);
            var result = categoryService.Queryable();
            Assert.IsNotNull(result);
        }
    }
}
