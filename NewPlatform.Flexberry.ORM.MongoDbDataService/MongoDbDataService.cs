namespace NewPlatform.Flexberry.ORM
{
    using System;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.Business.Audit;
    using ICSSoft.STORMNET.FunctionalLanguage;
    using ICSSoft.STORMNET.FunctionalLanguage.SQLWhere;
    using ICSSoft.STORMNET.Security;
    using MongoDB.Driver;
    using System.Linq;
    using MongoDB.Bson;
    using Microsoft.Practices.Unity;
    using ICSSoft.Services;

    /// <summary>
    /// Flexberry ORM DataService for MongoDB Storage.
    /// </summary>
    public class MongoDbDataService : IDataService
    {
        /// <summary>
        /// Приватное поле для <see cref="SecurityManager"/>.
        /// </summary>
        private ISecurityManager _securityManager;

        /// <summary>
        /// The prv instance id.
        /// </summary>
        private Guid prvInstanceId = Guid.NewGuid();


        /// <summary>
        /// Строка подключения в формате mongodb://[username:password@]hostname[:port][/[database][?options]].
        /// </summary>
        public string CustomizationString
        {
            get;
            set;
        }
        public TypeUsage TypeUsage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Сервис подсистемы полномочий, который применяется для проверки прав доступа. Рекомендуется устанавливать его через конструктор, в противном случае используется настройка в Unity.
        /// </summary>
        public ISecurityManager SecurityManager
        {
            get
            {
                if (_securityManager == null)
                {
                    IUnityContainer container = UnityFactory.CreateContainer();
                    _securityManager = container.Resolve<ISecurityManager>();
                }

                return _securityManager;
            }

            protected set
            {
                _securityManager = value;
            }
        }

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

        /// <summary>
        /// Ключ инстанции сервиса.
        /// </summary>
        /// <returns></returns>
        public Guid GetInstanceId()
        {
            return prvInstanceId;
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
            IMongoDatabase database = GetDataBase();
            IMongoCollection<BsonDocument> collection = GetCollection(dobject, database);
            string dobjectKey = GutGUIDValue(dobject.__PrimaryKey);

            var filter = new BsonDocument() { { "uid", dobjectKey } };
            var cursor = collection.Find(filter);

            var obj = cursor.FirstOrDefault();

            if (obj == null)
                //ToDo: Согласовать с параметрами.
                throw new TypeLoadException(string.Format("Объект c ключом {0} отсутствует в базе.", dobjectKey));

            var dataObjectCache = new DataObjectCache();
            var clearDataObject = true;
            var view = new View(dobject.GetType(), View.ReadType.OnlyThatObject);
            Type doType = dobject.GetType();
            StorageStructForView[] StorageStruct = {Information.GetStorageStructForView(view, doType, StorageTypeEnum.SimpleStorage,
                new Information.GetPropertiesInExpressionDelegate(GetPropertiesInExpression), GetType()) };

            LoadingCustomizationStruct lc = new LoadingCustomizationStruct(GetInstanceId());
            lc.View = view;
            
            object[][] resValue = new object[1][];
            int rowIndex = 0;
            resValue[rowIndex] = new object[view.Properties.Length + 2];
            
            for (int i = 0; i < view.Properties.Length; i++)
            {
                string propertyName = view.Properties[i].Name;
                if (obj.Names.Contains(propertyName))
                    if (obj[propertyName].IsInt32)
                        resValue[rowIndex][i] = obj[propertyName].AsInt32;
                    else if (obj[propertyName].IsInt64)
                        resValue[rowIndex][i] = obj[propertyName].AsInt64;
                    else if (obj[propertyName].IsString)
                            resValue[rowIndex][i] = obj[propertyName].AsString;
                        else
                            throw new InvalidCastException();

            }

            resValue[rowIndex][view.Properties.Length] = Guid.Parse(obj[Information.GetPrimaryKeyStorageName(doType)].AsString); // Ключ
            resValue[rowIndex][view.Properties.Length + 1] = 0; // Тип объекта?
            Utils.ProcessingRowsetDataRef(resValue, new Type[] { doType }, StorageStruct, lc, new DataObject[] { dobject }, this, null, clearDataObject, dataObjectCache, SecurityManager);

        }

        public static string GutGUIDValue(Object obj)
        {

            //ToDo: Разобраться с ключами.
            return obj.ToString().Replace("{", string.Empty).Replace("}", string.Empty).ToUpper();
        }

        private static IMongoCollection<BsonDocument> GetCollection(DataObject dobject, IMongoDatabase database)
        {
            string classStorageName = Information.GetClassStorageName(dobject.GetType());
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(classStorageName);
            return collection;
        }

        private IMongoDatabase GetDataBase()
        {
            MongoClient client = new MongoClient(CustomizationString);
            string dataBaseName = GetDataBaseName(client);
            IMongoDatabase database = client.GetDatabase(dataBaseName);
            return database;
        }

        /// <summary>
        /// Получить имя базы данных.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private static string GetDataBaseName(MongoClient client)
        {
            return client.Settings.Credentials.ToList()[0].Source;
        }

        public string[] GetPropertiesInExpression(string expression, string namespacewithpoint)
        {
            return Information.GetPropertiesInExpression(expression, namespacewithpoint);
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

        virtual public void UpdateObject(ref DataObject dobject, DataObjectCache DataObjectCache)
        {
            UpdateObject(ref dobject, DataObjectCache, false);
        }

        /// <summary>
        /// Обновление объекта данных
        /// </summary>
        /// <param name="dobject">объект данных, который требуется обновить</param>
        virtual public void UpdateObject(ref DataObject dobject, DataObjectCache DataObjectCache, bool AlwaysThrowException)
        {
            DataObject[] arr = new DataObject[] { dobject };
            UpdateObjects(ref arr, DataObjectCache, AlwaysThrowException);
            if (arr != null && arr.Length > 0)
                dobject = arr[0];
            else
                dobject = null;
        }

        virtual public void UpdateObject(DataObject dobject)
        {
            UpdateObject(dobject, false);
        }

        /// <summary>
        /// Обновление объекта данных
        /// </summary>
        /// <param name="dobject">объект данных, который требуется обновить</param>
        virtual public void UpdateObject(DataObject dobject, DataObjectCache DataObjectCache)
        {
            UpdateObject(ref dobject, DataObjectCache);
        }

        /// <summary>
        /// Обновление объекта данных
        /// </summary>
        /// <param name="dobject">объект данных, который требуется обновить</param>
        virtual public void UpdateObject(ICSSoft.STORMNET.DataObject dobject, bool AlwaysThrowException)
        {
            UpdateObject(ref dobject, new DataObjectCache(), AlwaysThrowException);
        }

        virtual public void UpdateObject(ref ICSSoft.STORMNET.DataObject dobject)
        {
            UpdateObject(ref dobject, false);
        }

        /// <summary>
        /// Обновление объекта данных
        /// </summary>
        /// <param name="dobject">объект данных, который требуется обновить</param>
        virtual public void UpdateObject(ref ICSSoft.STORMNET.DataObject dobject, bool AlwaysThrowException)
        {
            UpdateObject(ref dobject, new DataObjectCache(), AlwaysThrowException);
        }

        /// <summary>
        /// Обновить хранилище по объектам. При ошибках делается попытка возобновления транзакции с другого запроса, 
        /// т.к. предполагается, что запросы должны быть выполнены в другом порядке.
        /// </summary>
        /// <param name="objects">Объекты данных для обновления.</param>
        /// <param name="DataObjectCache">Кэш объектов данных.</param>
        public virtual void UpdateObjects(ref DataObject[] objects, DataObjectCache DataObjectCache)
        {
            UpdateObjects(ref objects, DataObjectCache, false);
        }

        public void UpdateObjects(ref DataObject[] objects, DataObjectCache DataObjectCache, bool AlwaysThrowException)
        {
            IMongoDatabase database = GetDataBase();

            foreach (DataObject obj in objects)
            {
                Type objType = obj.GetType();
                IMongoCollection<BsonDocument> collection = GetCollection(obj, database);

                switch (obj.GetStatus())
                {
                    case ObjectStatus.Deleted:
                        string objKey = GutGUIDValue(obj.__PrimaryKey);
                        var filter = new BsonDocument() { { "uid", objKey} };
                        var cursor = collection.Find(filter);

                        collection.DeleteOne(filter);

                        break;
                    case ObjectStatus.Created:
                        string[] properties = Information.GetPropertyNamesForInsert(objType);

                        BsonDocument doc = new BsonDocument();

                        foreach (string property in properties)
                        {
                            object value = Information.GetPropValueByName(obj, property);
                            string propertyToStore = property;
                            if (value != null)
                            {
                                if (property == "__PrimaryKey")
                                    propertyToStore = Information.GetPrimaryKeyStorageName(objType);
                                doc.Add(propertyToStore, ToBsonValue(value));
                            }
                        }
                        
                        collection.InsertOne(doc);
                        break;
                }
            }
        }

        private BsonValue ToBsonValue(object value)
        {
            if (value == null)
                return BsonNull.Value;
            else if (value.GetType() == typeof(int))
                return new BsonInt32((int)value);
            else if (value.GetType() == typeof(long))
                return new BsonInt64((long)value);
            else if (value.GetType() == typeof(string))
                return new BsonString((string)value);
            else if (value.GetType() == typeof(ICSSoft.STORMNET.KeyGen.KeyGuid))
                return GutGUIDValue(value);
            else
                throw new NotImplementedException();
        }

        /// <summary>
        /// Обновить хранилище по объектам.
        /// </summary>
        /// <param name="objects">Объекты данных для обновления.</param>
        public virtual void UpdateObjects(ref DataObject[] objects)
        {
            UpdateObjects(ref objects, new DataObjectCache());
        }

        /// <summary>
        /// Обновить хранилище по объектам.
        /// </summary>
        /// <param name="objects">Объекты данных для обновления.</param>
        /// <param name="AlwaysThrowException">Если произошла ошибка в базе данных, не пытаться выполнять других запросов, сразу взводить ошибку и откатывать транзакцию.</param>
        public virtual void UpdateObjects(ref DataObject[] objects, bool AlwaysThrowException)
        {
            UpdateObjects(ref objects, new DataObjectCache(), AlwaysThrowException);
        }
    }
}
