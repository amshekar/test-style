using System;
using System.Linq.Expressions;
using System.Threading;
using InternalApp.Entities;

using NUnit.Framework;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Fakes;
using Repository.Pattern.Repositories;

namespace InternalApp.Services.UnitTest
{
    [TestFixture]
    public class FakeDbContextTests : FakeDbContext
    {
        [Test]
        public void TestMethod1()
        {
            base.SaveChanges();
            base.SyncObjectState<Category>(new Category());
            CancellationToken ct;
            base.SaveChangesAsync(ct);
            base.SaveChangesAsync();
            base.Dispose();
        }
    }
}
