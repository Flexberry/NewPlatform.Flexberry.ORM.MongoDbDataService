using ICSSoft.STORMNET;
using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET.FunctionalLanguage;
using ICSSoft.STORMNET.Windows.Forms;
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
            var s = "CfswxOvvhE6+z96T2ToNpA==";
            var v = Convert.FromBase64String(s);
            Guid g = new Guid(v);
            var s1 = Convert.ToBase64String(g.ToByteArray());
            Assert.AreEqual(s1, s);


        }

        [TestMethod()]
        public void LoadObjectsTest()
        {
            var ds = DataServiceProvider.DataService;
            var obj = new Event();

            var view = new View(obj.GetType(), View.ReadType.OnlyThatObject);
            LoadingCustomizationStruct lc = new LoadingCustomizationStruct(ds.GetInstanceId());
            lc.LoadingTypes = new[] { obj.GetType() };
            lc.View = view;
            lc.ReturnTop = 100;
            var langdef = ExternalLangDef.LanguageDef;
            lc.LimitFunction = langdef.GetFunction(langdef.funcEQ,
                new VariableDef(langdef.StringType, Information.ExtractPropertyPath<Event>(x => x.grz)), "Я692ДЛ159");

            var result = ds.LoadObjects(lc);
            Assert.AreEqual(lc.ReturnTop, result.Length);
        }


        [TestMethod()]
        public void LimitFunctionToDocumentTest()
        {
            var ds = DataServiceProvider.DataService;
            var obj = new Event();

            var langdef = ExternalLangDef.LanguageDef;
            var lf =
                langdef.GetFunction(langdef.funcOR,

                langdef.GetFunction(langdef.funcEQ,
                new VariableDef(langdef.StringType, Information.ExtractPropertyPath<Event>(x => x.grz)), "Я692ДЛ159"),

                langdef.GetFunction(langdef.funcEQ,
                new VariableDef(langdef.StringType, Information.ExtractPropertyPath<Event>(x => x.grz)), "З806ФП190")
                );

            var result = ((MongoDbDataService)ds).LimitFunctionToDocument(lf, obj.GetType());
            //Assert.AreEqual(lc.ReturnTop, result.Length);
        }

        [TestMethod()]
        public void DetailTest()
        {
            var ds = DataServiceProvider.DataService;
            var obj = new RegObject();

            obj.__PrimaryKey = Convert.FromBase64String("KoT76tuKZOfpaCBd50STAw==");

            var view = new View(obj.GetType(), View.ReadType.OnlyThatObject);
            view.AddDetailInView("Cameras", new View(typeof(Camera), View.ReadType.OnlyThatObject), true);
            LoadingCustomizationStruct lc = new LoadingCustomizationStruct(ds.GetInstanceId());

            ds.LoadObject(view, obj);
            
        }

        [TestMethod()]
        public void GetObjectsCountTest()
        {
            var ds = DataServiceProvider.DataService;
            var obj = new Event();

            LoadingCustomizationStruct lc = new LoadingCustomizationStruct(ds.GetInstanceId());


            lc.LoadingTypes = new[] { obj.GetType() };
            var langdef = ExternalLangDef.LanguageDef;
            lc.LimitFunction =     langdef.GetFunction(langdef.funcOR,

                        langdef.GetFunction(langdef.funcEQ,
                        new VariableDef(langdef.StringType, Information.ExtractPropertyPath<Event>(x => x.grz)), "Я692ДЛ159"),

                        langdef.GetFunction(langdef.funcEQ,
                        new VariableDef(langdef.StringType, Information.ExtractPropertyPath<Event>(x => x.grz)), "З806ФП190")
                        );
            int count = ds.GetObjectsCount(lc);
 
        }

        [TestMethod()]
        public void LimitFunctionWithPrimaryKeyTest()
        {
            var ds = DataServiceProvider.DataService;
            var obj = new Event();

            LoadingCustomizationStruct lc = new LoadingCustomizationStruct(ds.GetInstanceId());


            lc.LoadingTypes = new[] { obj.GetType() };
            var langdef = ExternalLangDef.LanguageDef;
            lc.LimitFunction = 
                        langdef.GetFunction(langdef.funcEQ,
                        new VariableDef(langdef.GuidType, Information.ExtractPropertyPath<Event>(x => x.__PrimaryKey)), Guid.Parse("{56edde8f-4a09-4463-b6da-1cd68d183415}"));
            int count = ds.GetObjectsCount(lc);

        }
    }
}