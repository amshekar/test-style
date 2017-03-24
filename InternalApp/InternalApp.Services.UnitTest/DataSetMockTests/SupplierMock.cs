﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InternalApp.Entities;
using InternalApp.Repository;

using NUnit.Framework;
using Moq;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;

namespace InternalApp.Services.UnitTest
{
    [TestFixture]
    public class SupplierMock
    {
        Mock<DataContext> dataContext;
        Mock<IUnitOfWorkAsync> unitOfwork;
        ISupplierRepository suppRepo;
        ISupplierService suppService;
        Mock<DbSet<Supplier>> databaseSet;
        List<Supplier> suppList;
        Mock<DbSqlQuery<Supplier>> dbSqlQuery;
        object[] name;
        Mock<IQueryObject<Supplier>> suppQueryObject;

        public SupplierMock()
        {
            suppQueryObject = new Mock<IQueryObject<Supplier>>();
            name = new object[] { "test" };
            dbSqlQuery = new Mock<DbSqlQuery<Supplier>>();
            suppList = new List<Supplier>();
            suppList.Add(new Supplier() { CompanyName = "Company1", SupplierId = 1 });
            suppList.Add(new Supplier() { CompanyName = "Company2", SupplierId = 2 });
            suppList.Add(new Supplier() { CompanyName = "Company3", SupplierId = 3 });
            dataContext = new Mock<DataContext>();
            unitOfwork = new Mock<IUnitOfWorkAsync>();
            databaseSet = new Mock<DbSet<Supplier>>();
            dataContext.Setup(x => x.Set<Supplier>()).Returns(databaseSet.Object);
            suppRepo = new SupplierRepository(dataContext.Object, unitOfwork.Object);
            suppService = new SupplierService(suppRepo);
        }

        [Test]
        public void SupplierRepository_Tests()
        {
            databaseSet.Setup(x => x.Find(name)).Returns(suppList.FirstOrDefault());
            var result = suppService.Find(name);
            dataContext.VerifyAll();
            Assert.AreEqual(suppList.FirstOrDefault(), result);
        }

        [Test]
        public void SelectQuery_Tests()
        {
            databaseSet.Setup(x => x.SqlQuery("", name)).Returns(dbSqlQuery.Object);
            var result = suppService.SelectQuery("", name);
            databaseSet.VerifyAll();
            dataContext.VerifyAll();
            Assert.IsTrue(true, result.ToString());
        }

        [Test]
        public void GetRepository_Tests()
        {
            unitOfwork.Setup(x => x.Repository<Supplier>()).Returns(suppRepo);
            var result = suppRepo.GetRepository<Supplier>();
            databaseSet.VerifyAll();
            unitOfwork.VerifyAll();
            Assert.IsTrue(true, result.ToString());
        }

        [Test]
        public void Insert_Update_Test()
        {
            databaseSet.Setup(x => x.Attach(suppList.First()));
            dataContext.Setup(x => x.SaveChanges()).Returns(1);
            suppService.Insert(suppList.First());
            suppService.Update(suppList.First());
            databaseSet.VerifyAll();
            dataContext.VerifyAll();
        }

        [Test]
        public void InsertRange_UpdateRange_DeleteRange_Tests()
        {
            databaseSet.Setup(x => x.AddRange(suppList));
            databaseSet.Setup(x => x.RemoveRange(suppList));
            dataContext.Setup(x => x.SaveChanges()).Returns(1);
            suppService.InsertRange(suppList);
            suppService.UpdateRange(suppList);
            suppService.DeleteRange(suppList);
            databaseSet.VerifyAll();
            dataContext.VerifyAll();
        }

        [Test]
        public void InsertGraphRange_Tests()
        {
            databaseSet.Setup(x => x.AddRange(suppList)).Returns(suppList);
            suppService.InsertGraphRange(suppList);
            databaseSet.VerifyAll();
        }

        [Test]
        public void Delete_Tests()
        {
            databaseSet.Setup(x => x.Find(It.IsAny<object[]>())).Returns(suppList.FirstOrDefault());
            databaseSet.Setup(x => x.Remove(suppList.FirstOrDefault())).Returns(suppList.FirstOrDefault());
            dataContext.Setup(x => x.SaveChanges()).Returns(1);
            suppService.Delete(1);
            databaseSet.VerifyAll();
            dataContext.VerifyAll();
        }

        [Test]
        public void Query_Tests()
        {
            suppService.Query();
        }

        [Test]
        public void Query_WithParam_Tests()
        {
            suppService.Query(suppQueryObject.Object);
        }

        [Test]
        public void FindAsync_Tests()
        {
            CancellationToken ct;
            Task<Supplier> mockTask = new Task<Supplier>(() => new Supplier());
            databaseSet.Setup(x => x.FindAsync(It.IsAny<object[]>())).Returns(mockTask);
            databaseSet.Setup(x => x.FindAsync(ct, It.IsAny<object[]>())).Returns(mockTask);
            suppService.FindAsync(name);
            suppService.FindAsync(ct, name);
            databaseSet.VerifyAll();
        }

        [Test]
        public void DeleteAsync_Tests()
        {
            CancellationToken ct;
            Task<Supplier> mockTask = new Task<Supplier>(() => new Supplier());
            suppService.DeleteAsync(name);
            suppService.DeleteAsync(ct, name);
            databaseSet.VerifyAll();
        }

        [Test]
        public void InsertOrUpdateGraph_Tests()
        {
            databaseSet.Setup(x => x.Attach(suppList.First()));
            //     dataContext.Setup(x => x.SyncObjectState(It.IsAny<Supplier>()));
            suppService.InsertOrUpdateGraph(suppList.FirstOrDefault());
            databaseSet.VerifyAll();
            dataContext.VerifyAll();
        }
    }
}
