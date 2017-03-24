using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternalApp.Entities;

using NUnit.Framework;
using Repository.Pattern.Ef6.Fakes;
using Repository.Pattern.Infrastructure;

namespace InternalApp.Services.UnitTest
{
    /// <summary>
    /// FakeDbSetTest
    /// </summary>
    [TestFixture]
    public class FakeDbSetTest : FakeDbSet<Category>
    {
        /// <summary>
        /// Gets the enumerator tests.
        /// </summary>
        [Test]
        public void GetEnumeratorTests()
        {
            var result = base.GetEnumerator();
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Adds the tests.
        /// </summary>
        [Test]
        public void AddTests()
        {
            Category category = new Category();
            var result = base.Add(category);
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Removes the tests.
        /// </summary>
        [Test]
        public void RemoveTests()
        {
            Category category = new Category();
            var result = base.Remove(category);
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Attaches the tests.
        /// </summary>
        [Test]
        public void AttachTests()
        {
            Category category = new Category() { ObjectState = ObjectState.Modified };
            Category category1 = new Category() { ObjectState = ObjectState.Deleted };
            Category category2 = new Category() { ObjectState = ObjectState.Unchanged };
            var modify = base.Attach(category);
            var delete = base.Attach(category1);
            var unchanged = base.Attach(category2);
            Assert.IsNotNull(modify);
            Assert.IsNotNull(delete);
            Assert.IsNotNull(unchanged);
        }

        /// <summary>
        /// Creates the tests.
        /// </summary>
        [Test]
        public void CreateTests()
        {
            Category category = new Category();
            var result = base.Create();
            Assert.IsNotNull(result);
        }

    }
}
