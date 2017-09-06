namespace NewPlatform.Flexberry.ORM
{
    using System;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.Business.Audit;
    using ICSSoft.STORMNET.FunctionalLanguage;
    using ICSSoft.STORMNET.FunctionalLanguage.SQLWhere;
    using ICSSoft.STORMNET.Security;

    /// <summary>
    /// Flexberry ORM DataService for MongoDB Storage.
    /// </summary>
    public class MongoDbDataService : IDataService
    {
        public string CustomizationString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TypeUsage TypeUsage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ISecurityManager SecurityManager => throw new NotImplementedException();

        public IAuditService AuditService => throw new NotImplementedException();

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public void CompleteLoadStringedObjectView(ref object state)
        {
            throw new NotImplementedException();
        }

        public string FunctionToSql(SQLWhereLanguageDef sqlLangDef, Function function, delegateConvertValueToQueryValueString convertValue, delegatePutIdentifierToBrackets convertIdentifier)
        {
            throw new NotImplementedException();
        }

        public Guid GetInstanceId()
        {
            throw new NotImplementedException();
        }

        public int GetObjectsCount(LoadingCustomizationStruct customizationStruct)
        {
            throw new NotImplementedException();
        }

        public void LoadObject(DataObject dobject, DataObjectCache DataObjectCache)
        {
            throw new NotImplementedException();
        }

        public void LoadObject(string dataObjectViewName, DataObject dobject, DataObjectCache DataObjectCache)
        {
            throw new NotImplementedException();
        }

        public void LoadObject(View dataObjectView, DataObject dobject, DataObjectCache DataObjectCache)
        {
            throw new NotImplementedException();
        }

        public void LoadObject(DataObject dobject, bool ClearDataObject, bool CheckExistingObject, DataObjectCache DataObjectCache)
        {
            throw new NotImplementedException();
        }

        public void LoadObject(string dataObjectViewName, DataObject dobject, bool ClearDataObject, bool CheckExistingObject, DataObjectCache DataObjectCache)
        {
            throw new NotImplementedException();
        }

        public void LoadObject(View dataObjectView, DataObject dobject, bool ClearDataObject, bool CheckExistingObject, DataObjectCache DataObjectCache)
        {
            throw new NotImplementedException();
        }

        public void LoadObject(DataObject dobject)
        {
            throw new NotImplementedException();
        }

        public void LoadObject(string dataObjectViewName, DataObject dobject)
        {
            throw new NotImplementedException();
        }

        public void LoadObject(View dataObjectView, DataObject dobject)
        {
            throw new NotImplementedException();
        }

        public void LoadObject(DataObject dobject, bool ClearDataObject, bool CheckExistingObject)
        {
            throw new NotImplementedException();
        }

        public void LoadObject(string dataObjectViewName, DataObject dobject, bool ClearDataObject, bool CheckExistingObject)
        {
            throw new NotImplementedException();
        }

        public void LoadObject(View dataObjectView, DataObject dobject, bool ClearDataObject, bool CheckExistingObject)
        {
            throw new NotImplementedException();
        }

        public void LoadObjects(DataObject[] dataobjects, View dataObjectView, bool ClearDataobject, DataObjectCache DataObjectCache)
        {
            throw new NotImplementedException();
        }

        public DataObject[] LoadObjects(LoadingCustomizationStruct customizationStruct, DataObjectCache DataObjectCache)
        {
            throw new NotImplementedException();
        }

        public DataObject[] LoadObjects(LoadingCustomizationStruct customizationStruct, ref object State, DataObjectCache DataObjectCache)
        {
            throw new NotImplementedException();
        }

        public DataObject[] LoadObjects(ref object State, DataObjectCache DataObjectCache)
        {
            throw new NotImplementedException();
        }

        public void LoadObjects(DataObject[] dataobjects, View dataObjectView, bool ClearDataobject)
        {
            throw new NotImplementedException();
        }

        public DataObject[] LoadObjects(View dataObjectView)
        {
            throw new NotImplementedException();
        }

        public DataObject[] LoadObjects(View[] dataObjectViews)
        {
            throw new NotImplementedException();
        }

        public DataObject[] LoadObjects(LoadingCustomizationStruct[] customizationStructs)
        {
            throw new NotImplementedException();
        }

        public DataObject[] LoadObjects(View dataObjectView, ChangeViewForTypeDelegate changeViewForTypeDelegate)
        {
            throw new NotImplementedException();
        }

        public DataObject[] LoadObjects(View[] dataObjectViews, ChangeViewForTypeDelegate changeViewForTypeDelegate)
        {
            throw new NotImplementedException();
        }

        public DataObject[] LoadObjects(LoadingCustomizationStruct[] customizationStructs, ChangeViewForTypeDelegate changeViewForTypeDelegate)
        {
            throw new NotImplementedException();
        }

        public DataObject[] LoadObjects(LoadingCustomizationStruct customizationStruct)
        {
            throw new NotImplementedException();
        }

        public DataObject[] LoadObjects(LoadingCustomizationStruct customizationStruct, ref object State)
        {
            throw new NotImplementedException();
        }

        public DataObject[] LoadObjects(ref object State)
        {
            throw new NotImplementedException();
        }

        public ObjectStringDataView[] LoadStringedObjectView(char separator, LoadingCustomizationStruct customizationStruct)
        {
            throw new NotImplementedException();
        }

        public ObjectStringDataView[] LoadStringedObjectView(char separator, LoadingCustomizationStruct customizationStruct, ref object State)
        {
            throw new NotImplementedException();
        }

        public ObjectStringDataView[] LoadStringedObjectView(ref object state)
        {
            throw new NotImplementedException();
        }

        public ObjectStringDataView[] LoadValues(char separator, LoadingCustomizationStruct customizationStruct)
        {
            throw new NotImplementedException();
        }

        public void UpdateObject(ref DataObject dobject, DataObjectCache DataObjectCache)
        {
            throw new NotImplementedException();
        }

        public void UpdateObject(DataObject dobject)
        {
            throw new NotImplementedException();
        }

        public void UpdateObject(DataObject dobject, DataObjectCache DataObjectCache)
        {
            throw new NotImplementedException();
        }

        public void UpdateObject(ref DataObject dobject, DataObjectCache DataObjectCache, bool AlwaysThrowException)
        {
            throw new NotImplementedException();
        }

        public void UpdateObject(DataObject dobject, bool AlwaysThrowException)
        {
            throw new NotImplementedException();
        }

        public void UpdateObject(ref DataObject dobject)
        {
            throw new NotImplementedException();
        }

        public void UpdateObject(ref DataObject dobject, bool AlwaysThrowException)
        {
            throw new NotImplementedException();
        }

        public void UpdateObjects(ref DataObject[] objects, DataObjectCache DataObjectCache)
        {
            throw new NotImplementedException();
        }

        public void UpdateObjects(ref DataObject[] objects, DataObjectCache DataObjectCache, bool AlwaysThrowException)
        {
            throw new NotImplementedException();
        }

        public void UpdateObjects(ref DataObject[] objects)
        {
            throw new NotImplementedException();
        }

        public void UpdateObjects(ref DataObject[] objects, bool AlwaysThrowException)
        {
            throw new NotImplementedException();
        }
    }
}
