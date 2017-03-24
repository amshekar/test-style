using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Moq;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.UnitOfWork;

namespace InternalApp.Services.UnitTest
{
    /// <summary>
    /// UnitOfWorkMock class
    /// </summary>
    [TestFixture]
    public class UnitOfWorkMock
    {
        /// <summary>
        /// The _mock data context asynchronous
        /// </summary>
        Mock<IDataContextAsync> mockDataContextAsync;

        /// <summary>
        /// The unitof work
        /// </summary>
        IUnitOfWorkAsync unitofWork;

        /// <summary>
        /// Tests the initialize.
        /// </summary>
        public UnitOfWorkMock()
        {
            mockDataContextAsync = new Mock<IDataContextAsync>();
            unitofWork = new UnitOfWork(mockDataContextAsync.Object);
        }

        /// <summary>
        /// Unitofs the work_ save changes.
        /// </summary>
        [Test]
        public void UnitofWork_SaveChanges()
        {
            mockDataContextAsync = new Mock<IDataContextAsync>();
            unitofWork = new UnitOfWork(mockDataContextAsync.Object);
            int a = 1;
            mockDataContextAsync.Setup(x => x.SaveChanges()).Returns(a).Verifiable();
            var result = unitofWork.SaveChanges();
            Assert.AreEqual(a, result);
        }

        /// <summary>
        /// Unitofs the work_ save changes asynchronous.
        /// </summary>
        [Test]
        public void UnitofWork_SaveChangesAsync()
        {
            mockDataContextAsync = new Mock<IDataContextAsync>();
            unitofWork = new UnitOfWork(mockDataContextAsync.Object);
            Task<int> task = null;
            mockDataContextAsync.Setup(x => x.SaveChangesAsync()).Returns(task).Verifiable();
            var result = unitofWork.SaveChangesAsync();
            Assert.AreEqual(task, result);
        }

        /// <summary>
        /// Unitofs the work_ dispose.
        /// </summary>
        [Test]
        public void UnitofWork_Dispose()
        {
            mockDataContextAsync = new Mock<IDataContextAsync>();
            unitofWork = new UnitOfWork(mockDataContextAsync.Object);
            unitofWork.Dispose();
        }

        /// <summary>
        /// Unitofs the work_ disposing.
        /// </summary>
        [Test]
        public void UnitofWork_Disposing()
        {
            mockDataContextAsync = new Mock<IDataContextAsync>();
            unitofWork = new UnitOfWork(mockDataContextAsync.Object);
            bool disposing = true;
            unitofWork.Dispose(disposing);
        }
    }
}
