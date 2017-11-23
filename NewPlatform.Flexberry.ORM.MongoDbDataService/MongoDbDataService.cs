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
    using ICSSoft.STORMNET.KeyGen;
    using System.Collections.Generic;
    using ICSSoft.STORMNET.Windows.Forms;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Flexberry ORM DataService for MongoDB Storage.
    /// </summary>
    public class MongoDbDataService : IDataService
    {
        private ChangeViewForTypeDelegate fchangeViewForTypeDelegate = null;

        /// <summary>
        /// Construct data service with default settings.
        /// </summary>
        public MongoDbDataService()
        {
            // 
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
        }
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
            IMongoDatabase database = GetDataBase();
            Type type = customizationStruct.LoadingTypes.FirstOrDefault();
            IMongoCollection<BsonDocument> collection = GetCollection(type, database);

            string primaryKeyStorageName = Information.GetPrimaryKeyStorageName(type);

            BsonDocument filter = LimitFunctionToDocument(customizationStruct.LimitFunction, type);

            return (int)collection.Find(filter).Count();
        }

        /// <summary>
        /// Загрузка одного объекта данных
        /// </summary>
        /// <param name="dobject">объект данных, который требуется загрузить</param>
        /// <param name="ClearDataObject">очищать ли объект</param>
        /// <param name="CheckExistingObject">проверять ли существование объекта в хранилище</param>
        virtual public void LoadObject(
            ICSSoft.STORMNET.DataObject dobject, bool ClearDataObject, bool CheckExistingObject, DataObjectCache DataObjectCache)
        {
            LoadObject(new View(dobject.GetType(), View.ReadType.OnlyThatObject), dobject, ClearDataObject, CheckExistingObject, DataObjectCache);
        }
        /// <summary>
        /// Загрузка одного объекта данных
        /// </summary>
        /// <param name="dataObjectViewName">наименование представления</param>
        /// <param name="dobject">бъект данных, который требуется загрузить</param>
        /// <param name="ClearDataObject">очищать ли объект</param>
        /// <param name="CheckExistingObject">проверять ли существование объекта в хранилище</param>
        virtual public void LoadObject(
            string dataObjectViewName,
            ICSSoft.STORMNET.DataObject dobject, bool ClearDataObject, bool CheckExistingObject, DataObjectCache DataObjectCache)
        {
            LoadObject(Information.GetView(dataObjectViewName, dobject.GetType()), dobject, ClearDataObject, CheckExistingObject, DataObjectCache);
        }

        /// <summary>
        /// Загрузка одного объекта данных
        /// </summary>
        /// <param name="dataObjectView">представление объекта</param>
        /// <param name="dobject">объект данных, который требуется загрузить</param>
        virtual public void LoadObject(
            ICSSoft.STORMNET.View dataObjectView,
            ICSSoft.STORMNET.DataObject dobject, DataObjectCache DataObjectCache)
        {
            LoadObject(dataObjectView, dobject, true, true, DataObjectCache);
        }

        /// <summary>
        /// Загрузка одного объекта данных
        /// </summary>
        /// <param name="dataObjectViewName">имя представления объекта</param>
        /// <param name="dobject">объект данных, который требуется загрузить</param>
        virtual public void LoadObject(
            string dataObjectViewName,
            ICSSoft.STORMNET.DataObject dobject, DataObjectCache DataObjectCache)
        {
            LoadObject(Information.GetView(dataObjectViewName, dobject.GetType()), dobject, true, true, DataObjectCache);
        }

        /// <summary>
        /// Загрузка одного объекта данных
        /// </summary>
        /// <param name="dobject">объект данных, который требуется загрузить</param>
        virtual public void LoadObject(ICSSoft.STORMNET.DataObject dobject)
        {
            LoadObject(dobject, new DataObjectCache());
        }
        /// <summary>
        /// Загрузка одного объекта данных
        /// </summary>
        /// <param name="dataObjectViewName">имя представления объекта</param>
        /// <param name="dobject">объект данных, который требуется загрузить</param>
        virtual public void LoadObject(
            string dataObjectViewName,
            ICSSoft.STORMNET.DataObject dobject)
        {
            LoadObject(dataObjectViewName, dobject, new DataObjectCache());
        }
        /// <summary>
        /// Загрузка одного объекта данных
        /// </summary>
        /// <param name="dataObjectView">представление объекта</param>
        /// <param name="dobject">объект данных, который требуется загрузить</param>
        virtual public void LoadObject(
            ICSSoft.STORMNET.View dataObjectView,
            ICSSoft.STORMNET.DataObject dobject)
        {
            LoadObject(dataObjectView, dobject, new DataObjectCache());
        }
        /// <summary>
        /// Загрузка одного объекта данных
        /// </summary>
        /// <param name="dobject">объект данных, который требуется загрузить</param>
        /// <param name="ClearDataObject">очищать ли объект</param>
        /// <param name="CheckExistingObject">проверять ли существование объекта в хранилище</param>
        virtual public void LoadObject(
            ICSSoft.STORMNET.DataObject dobject, bool ClearDataObject, bool CheckExistingObject)
        {
            LoadObject(dobject, ClearDataObject, CheckExistingObject, new DataObjectCache());
        }
        /// <summary>
        /// Загрузка одного объекта данных
        /// </summary>
        /// <param name="dataObjectViewName">наименование представления</param>
        /// <param name="dobject">бъект данных, который требуется загрузить</param>
        /// <param name="ClearDataObject">очищать ли объект</param>
        /// <param name="CheckExistingObject">проверять ли существование объекта в хранилище</param>
        virtual public void LoadObject(
            string dataObjectViewName,
            ICSSoft.STORMNET.DataObject dobject, bool ClearDataObject, bool CheckExistingObject)
        {
            LoadObject(dataObjectViewName, dobject, ClearDataObject, CheckExistingObject, new DataObjectCache());
        }
        /// <summary>
        /// Загрузка одного объекта данных
        /// </summary>
        /// <param name="dataObjectView">представление</param>
        /// <param name="dobject">бъект данных, который требуется загрузить</param>
        /// <param name="ClearDataObject">очищать ли объект</param>
        /// <param name="CheckExistingObject">проверять ли существование объекта в хранилище</param>
        virtual public void LoadObject(
            ICSSoft.STORMNET.View dataObjectView,
            ICSSoft.STORMNET.DataObject dobject, bool ClearDataObject, bool CheckExistingObject)
        {
            LoadObject(dataObjectView, dobject, ClearDataObject, CheckExistingObject, new DataObjectCache());
        }
        /// <summary>
        /// Загрузка одного объекта данных
        /// </summary>
        /// <param name="dobject">объект данных, который требуется загрузить</param>
        virtual public void LoadObject(ICSSoft.STORMNET.DataObject dobject, DataObjectCache DataObjectCache)
        {
            LoadObject(new View(dobject.GetType(), View.ReadType.OnlyThatObject), dobject, true, true, DataObjectCache);
        }

        public void LoadObject(View dataObjectView, DataObject obj, bool clearDataObject, bool checkExistingObject, DataObjectCache DataObjectCache)
        {
            IMongoDatabase database = GetDataBase();
            IMongoCollection<BsonDocument> collection = GetCollection(obj.GetType(), database);
            Type type = obj.GetType();


            string primaryKeyStorageName = Information.GetPrimaryKeyStorageName(type);

            BsonDocument filter = new BsonDocument() { { primaryKeyStorageName, GetKeyValue(obj.__PrimaryKey) } };
            var cursor = collection.Find(filter);

            BsonDocument doc = cursor.FirstOrDefault();

            if (doc == null)
                //ToDo: Согласовать с параметрами.
                throw new TypeLoadException(string.Format("Объект c ключом {0} отсутствует в базе.", obj.__PrimaryKey));

            var dataObjectCache = new DataObjectCache();

            var view = new View(type, View.ReadType.OnlyThatObject);
            Type doType = obj.GetType();

            LoadingCustomizationStruct lc = new LoadingCustomizationStruct(GetInstanceId());
            lc.View = view;

            DataObjectCache cache = new DataObjectCache();
            FillObject(obj, doc, view, cache);

        }

        private void FillObject(DataObject dataObject, BsonDocument document, View view, DataObjectCache cache)
        {
            var dataObjectType = dataObject.GetType();

            for (int i = 0; i < view.Properties.Length; i++)
            {
                string propertyName = view.Properties[i].Name;
                object value = null;
                if (document.Names.Contains(propertyName))
                {
                    var propertyType = Information.GetPropertyType(dataObjectType, propertyName);
                    if (propertyType.IsSubclassOf(typeof(DataObject)))
                    {
                        value = GetDocumentProperty(document, propertyName);
                        DataObject master = cache.CreateDataObject(propertyType, propertyName);
                        LoadObject(master);
                        Information.SetPropValueByName(dataObject, propertyName, master);
                    }
                    else if (propertyType.IsSubclassOf(typeof(DetailArray)))
                    {
                    }
                    else if (!propertyName.Contains("."))
                    {
                        value = GetDocumentProperty(document, propertyName);
                        Information.SetPropValueByName(dataObject, propertyName, value);
                    }
                }
            }

            foreach (var detailInView in view.Details)
            {
                var detailArray = (DetailArray) Activator.CreateInstance(Information.GetPropertyType(dataObjectType, detailInView.Name));
                var detailType = detailInView.View.DefineClassType;
                LoadingCustomizationStruct lc = new LoadingCustomizationStruct(GetInstanceId());
                lc.LoadingTypes = new[] { detailType };
                lc.View = detailInView.View;

                var langdef = ExternalLangDef.LanguageDef;
                lc.LimitFunction = langdef.GetFunction(langdef.funcEQ,
                    new VariableDef(langdef.GuidType, Information.GetAgregatePropertyName(detailType)), dataObject.__PrimaryKey);

                var details = LoadObjects(lc);

                detailArray.AddRange(details);

            }
        }

        private static object GetDocumentProperty(BsonDocument document, string propertyName)
        {
            object value;
            if (document[propertyName].IsInt32)
                value = document[propertyName].AsInt32;
            else if (document[propertyName].IsInt64)
                value = document[propertyName].AsInt64;
            else if (document[propertyName].IsString)
                value = document[propertyName].AsString;
            else if (document[propertyName].IsGuid)
                value = document[propertyName].AsGuid;
            else if (document[propertyName].IsValidDateTime)
                value = document[propertyName].ToUniversalTime();
            else if (document[propertyName].IsDouble)
                value = document[propertyName].ToDouble();
            else if (document[propertyName].IsBsonArray)
                value = null;
            else
                throw new InvalidCastException();
            return value;
        }

        private static BsonValue GetKeyValue(object key)
        {

            if (key.GetType() == typeof(KeyGuid))
                return new BsonBinaryData(((KeyGuid)key).Guid.ToByteArray(), BsonBinarySubType.UuidStandard);
            else
                throw new Exception(string.Format("Unsupported key type: {0}.", key.GetType()));
        }

        public static IMongoCollection<BsonDocument> GetCollection(Type type, IMongoDatabase database)
        {
            string classStorageName = Information.GetClassStorageName(type);
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
        private string GetDataBaseName(MongoClient client)
        {
            var  m = Regex.Match(CustomizationString, @"(?<=\/)\w+?$");

            if (m.Success)
                return m.Value;

            throw new Exception("CustomizationString do not include dataBase name.");
        }

        public string[] GetPropertiesInExpression(string expression, string namespacewithpoint)
        {
            return Information.GetPropertiesInExpression(expression, namespacewithpoint);
        }

        /// <summary>
        /// Загрузка объектов данных
        /// </summary>
        /// <param name="dataobjects">исходные объекты</param>
        /// <param name="dataObjectView">представлене</param>
        /// <param name="ClearDataobject">очищать ли существующие</param>
        virtual public void LoadObjects(ICSSoft.STORMNET.DataObject[] dataobjects,
            ICSSoft.STORMNET.View dataObjectView, bool ClearDataobject)
        {
            LoadObjects(dataobjects, dataObjectView, ClearDataobject, new DataObjectCache());
        }

        /// <summary>
        /// Загрузка объектов данных
        /// </summary>
        /// <param name="customizationStruct">настроичная структура для выборки<see cref="LoadingCustomizationStruct"/></param>
        /// <returns>результат запроса</returns>
        virtual public ICSSoft.STORMNET.DataObject[] LoadObjects(
            LoadingCustomizationStruct customizationStruct)
        {
            return LoadObjects(customizationStruct, new DataObjectCache());
        }

        /// <summary>
        /// Загрузка объектов данных
        /// </summary>
        /// <param name="customizationStruct">настроичная структура для выборки<see cref="LoadingCustomizationStruct"/></param>
        /// <param name="State">Состояние вычитки( для последующей дочитки )</param>
        /// <returns></returns>
        virtual public ICSSoft.STORMNET.DataObject[] LoadObjects(
            LoadingCustomizationStruct customizationStruct,
            ref object State)
        {
            return LoadObjects(customizationStruct, ref State, new DataObjectCache());
        }

        /// <summary>
        /// Загрузка объектов данных
        /// </summary>
        /// <param name="State">Состояние вычитки( для последующей дочитки)</param>
        /// <returns></returns>
        virtual public ICSSoft.STORMNET.DataObject[] LoadObjects(ref object State)
        {
            return LoadObjects(ref State, new DataObjectCache());
        }


        /// <summary>
        /// Загрузка объектов данных
        /// </summary>
        /// <param name="customizationStruct">настроичная структура для выборки<see cref="LoadingCustomizationStruct"/></param>
        /// <returns></returns>
        virtual public ICSSoft.STORMNET.DataObject[] LoadObjects(
            LoadingCustomizationStruct customizationStruct, DataObjectCache DataObjectCache)
        {
            object state = null;
            ICSSoft.STORMNET.DataObject[] res = LoadObjects(customizationStruct, ref state, DataObjectCache);
            return res;
        }

        /// <summary>
        /// Загрузка объектов данных
        /// </summary>
        /// <param name="dataobjects">исходные объекты</param>
        /// <param name="dataObjectView">представлене</param>
        /// <param name="ClearDataobject">очищать ли существующие</param>
        virtual public void LoadObjects(ICSSoft.STORMNET.DataObject[] dataobjects,
            ICSSoft.STORMNET.View dataObjectView, bool ClearDataobject, DataObjectCache DataObjectCache)
        {
            if (dataobjects == null || dataobjects.Length == 0) return;

            /*if (!DoNotChangeCustomizationString && ChangeCustomizationString != null)
            {
                System.Collections.Generic.List<Type> tps = new System.Collections.Generic.List<Type>();
                foreach (DataObject d in dataobjects)
                {
                    Type t = d.GetType();
                    if (!tps.Contains(t))
                    {
                        tps.Add(t);
                    }
                }
                string cs = ChangeCustomizationString(tps.ToArray());
                customizationString = string.IsNullOrEmpty(cs) ? customizationString : cs;
            }*/

            DataObjectCache.StartCaching(false);
            /*try
            {
                System.Collections.ArrayList ALtypes = new System.Collections.ArrayList();
                System.Collections.ArrayList ALKeys = new System.Collections.ArrayList();
                System.Collections.SortedList ALobjectsKeys = new System.Collections.SortedList();
                System.Collections.SortedList readingKeys = new System.Collections.SortedList();
                for (int i = 0; i < dataobjects.Length; i++)
                {
                    DataObject dobject = dataobjects[i];
                    Type dotype = dobject.GetType();
                    bool addobj = false;
                    if (ALtypes.Contains(dotype))
                        addobj = true;
                    else
                    {
                        if ((dotype == dataObjectView.DefineClassType || dotype.IsSubclassOf(dataObjectView.DefineClassType)) && Information.IsStoredType(dotype))
                        {
                            ALtypes.Add(dotype);
                            addobj = true;
                        }
                    }
                    if (addobj)
                    {
                        object readingKey = (dobject.Prototyped) ? dobject.__PrototypeKey : dobject.__PrimaryKey;
                        ALKeys.Add(readingKey);
                        ALobjectsKeys.Add(dotype.FullName + readingKey.ToString(), i);
                        readingKeys.Add(readingKey.ToString(), dobject.__PrimaryKey);
                    }
                }
                LoadingCustomizationStruct customizationStruct = new LoadingCustomizationStruct(GetInstanceId());

                FunctionalLanguage.SQLWhere.SQLWhereLanguageDef lang = ICSSoft.STORMNET.FunctionalLanguage.SQLWhere.SQLWhereLanguageDef.LanguageDef;
                FunctionalLanguage.VariableDef var = new ICSSoft.STORMNET.FunctionalLanguage.VariableDef(
                    lang.GetObjectTypeForNetType(KeyGen.KeyGenerator.Generator(dataObjectView.DefineClassType).KeyType), "STORMMainObjectKey");
                object[] keys = new object[ALKeys.Count + 1]; ALKeys.CopyTo(keys, 1);
                keys[0] = var;
                FunctionalLanguage.Function func = lang.GetFunction(lang.funcIN, keys);
                Type[] types = new Type[ALtypes.Count]; ALtypes.CopyTo(types);

                customizationStruct.Init(null, func, types, dataObjectView, null);

                STORMDO.Business.StorageStructForView[] StorageStruct;

                // Применим полномочия на строки.
                ApplyReadPermissions(customizationStruct, SecurityManager);

                string SelectString = string.Empty;
                SelectString = GenerateSQLSelect(customizationStruct, false, out StorageStruct, false);
                //получаем данные
                object State = null;

                object[][] resValue = (SelectString == string.Empty) ? new object[0][] : ReadFirst(
                    SelectString
                    , ref State, 0);
                if (resValue != null && resValue.Length != 0)
                {
                    DataObject[] loadobjects = new ICSSoft.STORMNET.DataObject[resValue.Length];
                    int ObjectTypeIndexPOs = resValue[0].Length - 1;
                    int keyIndex = StorageStruct[0].props.Length - 1;
                    while (StorageStruct[0].props[keyIndex].MultipleProp) keyIndex--;
                    keyIndex++;

                    for (int i = 0; i < resValue.Length; i++)
                    {
                        Type tp = types[Convert.ToInt64(resValue[i][ObjectTypeIndexPOs].ToString())];
                        object ky = resValue[i][keyIndex];
                        ky = Information.TranslateValueToPrimaryKeyType(tp, ky);
                        int indexobj = ALobjectsKeys.IndexOfKey(tp.FullName + ky.ToString());
                        if (indexobj > -1)
                        {
                            loadobjects[i] = dataobjects[(int)ALobjectsKeys.GetByIndex(indexobj)];
                            if (ClearDataobject)
                                loadobjects[i].Clear();
                            DataObjectCache.AddDataObject(loadobjects[i]);
                        }
                        else
                            loadobjects[i] = null;
                    }

                    Utils.ProcessingRowsetDataRef(resValue, types, StorageStruct, customizationStruct, loadobjects, this, Types, ClearDataobject, DataObjectCache, SecurityManager);
                    foreach (DataObject dobj in loadobjects)
                    {
                        if (dobj != null && dobj.Prototyped)
                        {
                            dobj.__PrimaryKey = readingKeys[dobj.__PrimaryKey.ToString()];
                            dobj.SetStatus(ObjectStatus.Created);
                            dobj.SetLoadingState(LoadingState.NotLoaded);
                        }
                    }
                }

            }
            finally
            {
                DataObjectCache.StopCaching();
            }*/
        }

        /// <summary>
        /// Загрузка объектов данных по представлению
        /// </summary>
        /// <param name="dataObjectView">представление</param>
        virtual public ICSSoft.STORMNET.DataObject[] LoadObjects(
            ICSSoft.STORMNET.View dataObjectView)
        {
            LoadingCustomizationStruct lc = new LoadingCustomizationStruct(GetInstanceId());
            lc.View = dataObjectView;
            lc.LoadingTypes = new[] { dataObjectView.DefineClassType };
            return LoadObjects(lc, new DataObjectCache());
        }

        /// <summary>
        /// Загрузка объектов данных по массиву представлений
        /// </summary>
        /// <param name="dataObjectViews">массив представлений</param>
        virtual public ICSSoft.STORMNET.DataObject[] LoadObjects(
            ICSSoft.STORMNET.View[] dataObjectViews)
        {
            System.Collections.ArrayList arr = new System.Collections.ArrayList();
            ICSSoft.STORMNET.DataObject[] res = null;
            for (int i = 0; i < dataObjectViews.Length; i++)
            {
                res = LoadObjects(dataObjectViews[i]);
                for (int j = 0; j < res.Length; j++)
                {
                    arr.Add(res[j]);
                }
            }
            res = new ICSSoft.STORMNET.DataObject[arr.Count];
            arr.CopyTo(res);
            return res;
        }

        /// <summary>
        /// Загрузка объектов данных по массиву структур
        /// </summary>
        /// <param name="customizationStructs">массив структур</param>
        virtual public ICSSoft.STORMNET.DataObject[] LoadObjects(
            LoadingCustomizationStruct[] customizationStructs)
        {
            System.Collections.ArrayList arr = new System.Collections.ArrayList();
            ICSSoft.STORMNET.DataObject[] res = null;
            for (int i = 0; i < customizationStructs.Length; i++)
            {
                res = LoadObjects(customizationStructs[i], new DataObjectCache());
                for (int j = 0; j < res.Length; j++)
                {
                    arr.Add(res[j]);
                }
            }
            res = new ICSSoft.STORMNET.DataObject[arr.Count];
            arr.CopyTo(res);
            return res;
        }

        /// <summary>
        /// Загрузка объектов данных
        /// </summary>
        /// <param name="customizationStruct">настроичная структура для выборки<see cref="LoadingCustomizationStruct"/></param>
        /// <param name="State">Состояние вычитки( для последующей дочитки )</param>
        /// <returns></returns>
        virtual public DataObject[] LoadObjects(
            LoadingCustomizationStruct customizationStruct,
            ref object State, DataObjectCache DataObjectCache)
        {
            DataObjectCache.StartCaching(false);
            try
            {
                IMongoDatabase database = GetDataBase();
                Type type = customizationStruct.LoadingTypes.FirstOrDefault();
                IMongoCollection<BsonDocument> collection = GetCollection(type, database);

                string primaryKeyStorageName = Information.GetPrimaryKeyStorageName(type);

                BsonDocument filter = LimitFunctionToDocument(customizationStruct.LimitFunction, type);

                var r = collection.Find(filter);

                if (customizationStruct.RowNumber != null)
                {
                    var rn = customizationStruct.RowNumber;
                    r = r.Skip(rn.StartRow).Limit(rn.EndRow - rn.StartRow);
                }

                if (customizationStruct.ColumnsSort != null)
                {
                    var sortbuilder = Builders<BsonDocument>.Sort;
                    SortDefinition<BsonDocument> sort = null;
                    foreach (var s in customizationStruct.ColumnsSort)
                    {
                        if (s.Sort == SortOrder.Asc)
                            sort = sort == null?sortbuilder.Ascending(s.Name):sort.Ascending(s.Name);
                        else if (s.Sort == SortOrder.Desc)
                            sort = sort == null ? sortbuilder.Descending(s.Name) : sort.Descending(s.Name);
                    }

                    if (sort!=null)
                        r = r.Sort(sort);
                }

                

                List<BsonDocument> documents = r.Limit(customizationStruct.ReturnTop).ToList();

                DataObject[] result = new DataObject[documents.Count];

                for (int i = 0; i < documents.Count; i++)
                {
                    BsonDocument doc = documents[i];
                    var obj = DataObjectCache.CreateDataObject(type, GetDocumentProperty(doc, primaryKeyStorageName));
                    FillObject(obj, doc, customizationStruct.View, DataObjectCache);
                    result[i] = obj;
                }
                return result;
            }
            finally
            {
                DataObjectCache.StopCaching();
            }

            return new DataObject[0];
        }

        /// <summary>
        /// Загрузка объектов данных по представлению
        /// </summary>
        /// <param name="dataObjectView">представление</param>
        /// <param name="changeViewForTypeDelegate">делегат</param>
        virtual public DataObject[] LoadObjects(
            View dataObjectView, ChangeViewForTypeDelegate changeViewForTypeDelegate)
        {
            if (changeViewForTypeDelegate != null)
            {
                fchangeViewForTypeDelegate = changeViewForTypeDelegate;
            }
            return LoadObjects(dataObjectView);
        }

        /// <summary>
        /// Загрузка объектов данных по массиву представлений
        /// </summary>
        /// <param name="dataObjectViews">массив представлений</param>
        /// <param name="changeViewForTypeDelegate">делегат</param>
        virtual public ICSSoft.STORMNET.DataObject[] LoadObjects(
            ICSSoft.STORMNET.View[] dataObjectViews, ChangeViewForTypeDelegate changeViewForTypeDelegate)
        {
            if (changeViewForTypeDelegate != null)
            {
                this.fchangeViewForTypeDelegate = changeViewForTypeDelegate;
            }
            return LoadObjects(dataObjectViews);
        }

        /// <summary>
        /// Загрузка объектов данных по массиву структур
        /// </summary>
        /// <param name="customizationStructs">массив структур</param>
        /// <param name="changeViewForTypeDelegate">делегат</param>
        virtual public ICSSoft.STORMNET.DataObject[] LoadObjects(
            LoadingCustomizationStruct[] customizationStructs, ChangeViewForTypeDelegate changeViewForTypeDelegate)
        {
            if (changeViewForTypeDelegate != null)
            {
                this.fchangeViewForTypeDelegate = changeViewForTypeDelegate;
            }
            return LoadObjects(customizationStructs);
        }

        /// <summary>
        /// Загрузка объектов данных
        /// </summary>
        /// <param name="State">Состояние вычитки( для последующей дочитки)</param>
        /// <returns></returns>
        virtual public DataObject[] LoadObjects(ref object State, DataObjectCache DataObjectCache)
        {
            if (State == null)
                return new DataObject[0];
            DataObjectCache.StartCaching(false);
            try
            {
                //получаем данные
                object[] stateArr = (object[])State;
                ICSSoft.STORMNET.DataObject[] res = null;
                if (stateArr[0] == null)
                    res = new DataObject[0];
                else
                {
                    object[][] resValue = null;//= ReadNext(ref stateArr[0], ((LoadingCustomizationStruct)stateArr[3]).LoadingBufferSize);
                    if (resValue == null)
                    {
                        res = new DataObject[0];
                    }
                    else
                    {
                        //res = Utils.ProcessingRowsetData(resValue, (System.Type[])stateArr[1], (StorageStructForView[])stateArr[2], (LoadingCustomizationStruct)stateArr[3],
                        //    this, Types, DataObjectCache, SecurityManager);
                    }
                }
                DataObjectCache.StopCaching();
                return res;
            }
            finally
            {
                DataObjectCache.StopCaching();
            }
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
        virtual public void UpdateObject(DataObject dobject, bool AlwaysThrowException)
        {
            UpdateObject(ref dobject, new DataObjectCache(), AlwaysThrowException);
        }

        virtual public void UpdateObject(ref DataObject dobject)
        {
            UpdateObject(ref dobject, false);
        }

        /// <summary>
        /// Обновление объекта данных
        /// </summary>
        /// <param name="dobject">объект данных, который требуется обновить</param>
        virtual public void UpdateObject(ref DataObject dobject, bool AlwaysThrowException)
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
                string primaryKeyStorageName = Information.GetPrimaryKeyStorageName(objType);
                IMongoCollection<BsonDocument> collection = GetCollection(obj.GetType(), database);

                switch (obj.GetStatus())
                {
                    case ObjectStatus.Deleted:
                        var filter = new BsonDocument() { { primaryKeyStorageName, GetKeyValue(obj.__PrimaryKey) } };
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
            else if (value.GetType() == typeof(bool))
                return new BsonBoolean((bool)value);
            else if (value.GetType() == typeof(int))
                return new BsonInt32((int)value);
            else if (value.GetType() == typeof(long))
                return new BsonInt64((long)value);
            else if (value.GetType() == typeof(double))
                return new BsonDouble((double)value);
            else if (value.GetType() == typeof(string))
                return new BsonString((string)value);
            else if (value.GetType() == typeof(DateTime) || value.GetType() == typeof(ICSSoft.STORMNET.UserDataTypes.NullableDateTime))
                return new BsonDateTime((DateTime)value);
            else if (value.GetType() == typeof(Guid)) 
                return new BsonBinaryData(((Guid)value).ToByteArray(), BsonBinarySubType.UuidStandard);
            else if (value.GetType() == typeof(ICSSoft.STORMNET.KeyGen.KeyGuid))
                return GetKeyValue(value);
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

        public BsonDocument LimitFunctionToDocument(Function function, Type type)
        {
            if (function == null)
                return new BsonDocument();


            string attributeName = null;
            BsonValue value = null;

            foreach (object obj in function.Parameters)
            {
                if (obj is DetailVariableDef)
                    throw new NotSupportedException("DetailVariableDef");

                else if (obj is VariableDef)
                {
                    attributeName = ((VariableDef)obj).StringedView;
                    if (attributeName == "STORMMainObjectKey" || attributeName == "__PrimaryKey")
                        attributeName = Information.GetPrimaryKeyStorageName(type);

                }
                //else if (obj is Function)
                    //value= LimitFunctionToDocument((Function)obj);
                else
                {
                    value = ToBsonValue(obj);
                }



            }

            /*
             $eq
Matches values that are equal to a specified value.
$gt
Matches values that are greater than a specified value.
$gte
Matches values that are greater than or equal to a specified value.
$in
Matches any of the values specified in an array.
$lt
Matches values that are less than a specified value.
$lte
Matches values that are less than or equal to a specified value.
$ne
Matches all values that are not equal to a specified value.
$nin
Matches none of the values specified in an array.
             */

            if (function.FunctionDef.StringedView == SQLWhereLanguageDef.LanguageDef.funcEQ)
            {
                return new BsonDocument(attributeName, value);
            }
            if (function.FunctionDef.StringedView == SQLWhereLanguageDef.LanguageDef.funcG)
            {
                return new BsonDocument(attributeName, new BsonDocument("$gt", value.ToString()));
            }
            if (function.FunctionDef.StringedView == SQLWhereLanguageDef.LanguageDef.funcNEQ)
            {
                return new BsonDocument(attributeName, new BsonDocument("$ne", value.ToString()));
            }
            else if (function.FunctionDef.StringedView == SQLWhereLanguageDef.LanguageDef.funcAND)
            {
                var arr = new BsonArray();

                foreach (object obj in function.Parameters)
                    if (obj is Function)
                        arr.Add(LimitFunctionToDocument((Function)obj, type));

                return new BsonDocument("$and", arr);
            }
            else if (function.FunctionDef.StringedView == SQLWhereLanguageDef.LanguageDef.funcOR)
            {
                var arr = new BsonArray();

                foreach (object obj in function.Parameters)
                    if (obj is Function)
                        arr.Add(LimitFunctionToDocument((Function)obj, type));

                return new BsonDocument("$or", arr);
            }






            return new BsonDocument();
        }
    }
}
