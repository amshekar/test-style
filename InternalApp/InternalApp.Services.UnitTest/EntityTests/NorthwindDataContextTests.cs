using System;
using InternalApp.Entities.Context;

using NUnit.Framework;

namespace InternalApp.Services.UnitTest
{
    [TestFixture]
    public class NorthwindDataContextTests : NorthwindDataContext
    {
        [Test]
        public void NorthwindDataContext_Tests()
        {
            NorthwindDataContext context = new NorthwindDataContext();
            context.Suppliers = null;
            var con = context.Suppliers;
            base.OnModelCreating(new System.Data.Entity.DbModelBuilder());
            context.Categories = null;
            var conCat = context.Categories;
        }
    }
}
