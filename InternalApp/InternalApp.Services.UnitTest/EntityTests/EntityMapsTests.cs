using System;
using InternalApp.Entities.Context;
using InternalApp.Entities.Mappings;

using NUnit.Framework;

namespace InternalApp.Services.UnitTest
{
    [TestFixture]
    public class EntityMapsTests
    {
        [Test]
        public void CategoryMapTests()
        {
            CategoryMap map = new CategoryMap();
        }

        [Test]
        public void SupplierMapTests()
        {
            SupplierMap map = new SupplierMap();
        }

        [Test]
        public void NorthWindContext()
        {
            NorthwindDataContext context = new NorthwindDataContext();
        }
    }
}
