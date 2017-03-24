using System;
using System.Linq.Expressions;
using InternalApp.Entities;

using NUnit.Framework;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;

namespace InternalApp.Services.UnitTest
{
    [TestFixture]
    public class QueryObjectTests : QueryObject<Category>
    {
        Expression<Func<Category, bool>> query;

        [Test]
        public void QueryObject_Tests()
        {
            query = null;
            base.Query();
            base.And(query);
            base.Or(query);
        }
    }
}
