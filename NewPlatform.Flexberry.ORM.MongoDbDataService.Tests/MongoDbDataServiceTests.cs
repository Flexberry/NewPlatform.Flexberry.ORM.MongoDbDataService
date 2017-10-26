﻿using ICSSoft.STORMNET;
using ICSSoft.STORMNET.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;
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

            
            obj.__PrimaryKey = Convert.FromBase64String("MMvIKodsFEXrwGtg0/MTWw==");

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
            objRead.__PrimaryKey = obj.__PrimaryKey;

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
            objRead.__PrimaryKey = obj.__PrimaryKey;

            ds.LoadObject(objRead);

            objRead.SetStatus(ObjectStatus.Deleted);

            ds.UpdateObject(objRead);

            ds.LoadObject(objRead);
        }

    

        [TestMethod()]
        public void Guid1Test()
        {
            var s = "MMvIKodsFEXrwGtg0/MTWw==";
            var v = Convert.FromBase64String(s);
            Guid g = new Guid(v);
            var s1 = Convert.ToBase64String(g.ToByteArray());
            Assert.AreEqual(s1, s);


        }                     
    }
}