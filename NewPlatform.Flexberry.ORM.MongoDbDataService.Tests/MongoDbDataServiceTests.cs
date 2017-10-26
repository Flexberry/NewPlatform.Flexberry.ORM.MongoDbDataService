using ICSSoft.STORMNET;
using ICSSoft.STORMNET.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewPlatform.BigDataTest;
using NewPlatform.Flexberry.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPlatform.Flexberry.ORM.Tests
{
    [TestClass()]
    public class MongoDbDataServiceTests
    {
        [TestMethod()]
        public void LoadObjectTest()
        {
            var obj = new Event();

            obj.__PrimaryKey = "03BC8CA2-78C6-4154-BE0C-B6063D3F31B5";
            var ds = DataServiceProvider.DataService;

            ds.LoadObject(obj);

            Assert.AreEqual("Я692ДЛ159", obj.grz);
        }

        [TestMethod()]
        [ExpectedException(typeof(TypeLoadException))]
        public void LoadMissedObjectTest()
        {
            var obj = new Event();

            obj.__PrimaryKey = Guid.Parse("{15F5007C-7A7A-4F67-AF58-8B41AF73A2D9}");
            var ds = DataServiceProvider.DataService;

            ds.LoadObject(obj);

        }

        [TestMethod()]
        public void CreateAndSaveObjectTest()
        {
            var obj = new Event();

            var ds = DataServiceProvider.DataService;

            obj.grz = "23gggqqq";

            ds.UpdateObject(obj);

            var objRead = new Event();
            objRead.__PrimaryKey = MongoDbDataService.GutGUIDValue(obj.__PrimaryKey);

            ds.LoadObject(objRead);

            Assert.AreEqual(obj.grz, objRead.grz);
        }

        [TestMethod()]
        [ExpectedException(typeof(TypeLoadException))]
        public void DeleteObjectTest()
        {
            var obj = new Event();

            var ds = DataServiceProvider.DataService;

            obj.grz = "23gggqqq";

            ds.UpdateObject(obj);

            var objRead = new Event();
            objRead.__PrimaryKey = MongoDbDataService.GutGUIDValue(obj.__PrimaryKey);

            ds.LoadObject(objRead);

            objRead.SetStatus(ObjectStatus.Deleted);

            ds.UpdateObject(objRead);

            ds.LoadObject(objRead);
        }
    }
}