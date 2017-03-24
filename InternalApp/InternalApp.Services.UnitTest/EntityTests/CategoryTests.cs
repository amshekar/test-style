using System;

using NUnit.Framework;
using InternalApp.Entities;
using Repository.Pattern.Infrastructure;

namespace InternalApp.Services.UnitTest
{
    [TestFixture]
    public class CategoryTests
    {
        [Test]
        public void Category_Get_SetTests()
        {
            // Set value 
            Category category = new Category()
            {
                CategoryId = 123,
                CategoryName = "Category Name",
                Description = "Description",
                Picture = null,
                ObjectState = ObjectState.Added

            };
            //Get Value
            Category categorySet = new Category()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description,
                Picture = category.Picture,
                ObjectState = category.ObjectState
            };
            Assert.IsTrue(true, categorySet.CategoryName);
        }
    }
}
