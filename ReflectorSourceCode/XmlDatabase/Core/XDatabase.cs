namespace XmlDatabase.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Xml.Linq;
    using XmlDatabase.Core.Properties;

    public sealed class XDatabase : IDisposable
    {
        private bool autoSubmit;
        private static string DATABASECONFIGFILE = "CORE.XML";
        private string fullName;
        internal XIdsManager ids;
        private XTaskManager taskManager;

        private XDatabase()
        {
            this.autoSubmit = true;
        }

        private XDatabase(string _fullName) : this()
        {
            this.fullName = _fullName;
            this.ApplicationName = AppDomain.CurrentDomain.FriendlyName;
            this.UserName = Thread.CurrentPrincipal.Identity.Name;
            this.Log = new XLogWriter(this);
            this.ids = XIdsManager.GetInstance(this.FullName);
            this.taskManager = new XTaskManager(this);
            this.Log.WriteEx(Resources.DatabaseOpened, true);
        }

        public XTransaction BeginTransaction()
        {
            return new XTransaction(this);
        }

        public void Close()
        {
            this.Log.WriteLine(Resources.DatabaseClosed);
            this.Log.Close();
        }

        public void Configure(XTypeRegistration[] items)
        {
            XDocument document = XDocument.Load(DATABASECONFIGFILE);
            XElement element = document.Root.Element("Types");
            Func<XElement, bool> func = null;
            foreach (XTypeRegistration item in items)
            {
                string path = Path.Combine(this.FullName, @"Entities\" + item.FullName);
                Directory.CreateDirectory(path);
                Directory.CreateDirectory(path + @"\Data");
                Directory.CreateDirectory(path + @"\Index");
                if (func == null)
                {
                    func = f => f.Attribute("FullName").Value == item.FullName;
                }
                if (Enumerable.FirstOrDefault<XElement>(element.Elements("Type"), func) != null)
                {
                    XElement element2 = item.ConvertToXml("Type", Guid.Empty);
                }
                else
                {
                    element.Add(item.ConvertToXml("Type", Guid.Empty));
                }
                this.Log.WriteEx(string.Format(Resources.TypeConfiguration, item.FullName));
            }
            this.Log.Flush();
            document.Save(DATABASECONFIGFILE);
        }

        public void Delete(object instance)
        {
            if (this.autoSubmit)
            {
                Guid id = this.ids.GetObjectId(instance);
                if (id != Guid.Empty)
                {
                    this.ids.Remove(instance);
                    string fullName = instance.GetType().FullName;
                    string path = string.Format(@"{4}\{0}\{1}\{2}\{3}.xml", new object[] { "Entities", fullName, "Data", fullName, this.fullName });
                    if (File.Exists(path))
                    {
                        XDocument document = XDocument.Load(path);
                        Enumerable.FirstOrDefault<XElement>(document.Root.Elements(), (Func<XElement, bool>) (e => (e.Attribute("_uuid").Value == id.ToString()))).Remove();
                        document.Save(path);
                        this.Log.WriteEx(string.Format(Resources.DeleteObject, id, instance), true);
                    }
                }
            }
            else
            {
                XChangeItem task = new XChangeItem {
                    Action = XChangeAction.Delete,
                    UserData = instance
                };
                this.taskManager.AddTask(task);
            }
        }

        public void Delete(object[] objects)
        {
            foreach (object obj2 in objects)
            {
                this.Delete(obj2);
            }
        }

        public void Dispose()
        {
        }

        public IEnumerable<T> Get<T>()
        {
            return this.Query<T>();
        }

        public static XDatabase Open(string database)
        {
            XDatabase database2;
            DATABASECONFIGFILE = Path.Combine(database, "core.xml");
            try
            {
                if (Directory.Exists(database))
                {
                    if (!File.Exists(DATABASECONFIGFILE))
                    {
                        throw new FileNotFoundException();
                    }
                    return new XDatabase(database);
                }
                Directory.CreateDirectory(database);
                new XDocument(new object[] { new XElement("Database", new object[] { new XAttribute("CreateTime", DateTime.Now), new XAttribute("Version", XUtility.EngineVersion), new XElement("Types") }) }).Save(DATABASECONFIGFILE);
                database2 = new XDatabase(database);
            }
            catch (Exception exception)
            {
                throw new XDatabaseException("GeneralException", new string[] { exception.Message });
            }
            return database2;
        }

        public IEnumerable<T> Query<T>()
        {
            string fullName = typeof(T).FullName;
            string path = string.Format(@"{4}\{0}\{1}\{2}\{3}.xml", new object[] { "Entities", fullName, "Data", fullName, this.fullName });
            if (!File.Exists(path))
            {
                return Enumerable.Empty<T>();
            }
            IEnumerable<XElementExtensions.Entity> enumerable = from e in XDocument.Load(path).Root.Elements() select e.ConvertToObject<T>();
            List<T> source = new List<T>();
            foreach (XElementExtensions.Entity entity in enumerable)
            {
                this.ids.Set(entity.Instance, entity.Id);
                source.Add((T) entity.Instance);
            }
            this.Log.WriteEx(string.Format(Resources.QueryObject, source.Count<T>()), true);
            return source;
        }

        public void Store(object instance)
        {
            XElement element = (from e in XDocument.Load(DATABASECONFIGFILE).Root.Element("Types").Elements("Type")
                where e.Attribute("FullName").Value == instance.GetType().FullName
                select e).FirstOrDefault<XElement>();
            if (element == null)
            {
                XTypeRegistration[] items = new XTypeRegistration[1];
                XTypeRegistration registration = new XTypeRegistration {
                    FullName = instance.GetType().FullName
                };
                items[0] = registration;
                this.Configure(items);
                this.Store(instance, false);
            }
            else
            {
                this.Store(instance, bool.Parse(element.Attribute("SingleRowPerFile").Value));
            }
        }

        public void Store(object instance, bool singleFile)
        {
            string typeFullName = instance.GetType().FullName;
            string name = instance.GetType().Name;
            if ((from e in XDocument.Load(DATABASECONFIGFILE).Root.Element("Types").Elements("Type")
                where e.Attribute("FullName").Value == typeFullName
                select e).FirstOrDefault<XElement>() == null)
            {
                XTypeRegistration[] items = new XTypeRegistration[1];
                XTypeRegistration registration = new XTypeRegistration {
                    FullName = typeFullName
                };
                items[0] = registration;
                this.Configure(items);
            }
            string path = string.Format(@"{4}\{0}\{1}\{2}\{3}.xml", new object[] { "Entities", typeFullName, "Data", typeFullName, this.fullName });
            if (this.autoSubmit)
            {
                Func<XElement, bool> func = null;
                XDocument document2 = File.Exists(path) ? XDocument.Load(path) : new XDocument(new object[] { new XElement("XMLDatabase-Entities") });
                Guid id = this.ids.GetObjectId(instance);
                if (id != Guid.Empty)
                {
                    if (func == null)
                    {
                        func = e => e.Attribute("_uuid").Value == id.ToString();
                    }
                    XElement element2 = Enumerable.Where<XElement>(document2.Root.Elements(name), func).FirstOrDefault<XElement>();
                    XElement content = instance.ConvertToXml(id);
                    element2.ReplaceWith(content);
                    this.Log.WriteEx(string.Format(Resources.UpdateObject, id, instance.ToString()), true);
                }
                else
                {
                    id = Guid.NewGuid();
                    XElement element4 = instance.ConvertToXml(id);
                    document2.Root.Add(element4);
                    this.Log.WriteEx(string.Format(Resources.InsertObject, id, instance.ToString()), true);
                }
                document2.Save(path);
            }
            else
            {
                XChangeItem task = new XChangeItem {
                    Action = XChangeAction.AddOrUpdate,
                    UserData = instance
                };
                this.taskManager.AddTask(task);
            }
        }

        public XSubmitStatus SubmitChanges()
        {
            return this.SubmitChanges(true);
        }

        public XSubmitStatus SubmitChanges(bool continueOnError)
        {
            return this.taskManager.Execute(continueOnError, false);
        }

        public XSubmitStatus SubmitChangesWithTransaction()
        {
            return this.taskManager.Execute(false, true);
        }

        public string ApplicationName { get; set; }

        public bool AutoSubmitMode
        {
            get
            {
                return this.autoSubmit;
            }
            set
            {
                this.autoSubmit = value;
            }
        }

        public string FullName
        {
            get
            {
                return this.fullName;
            }
        }

        public TextWriter Log { get; set; }

        public List<XTypeRegistration> Types
        {
            get
            {
                return (from t in XDocument.Load(DATABASECONFIGFILE).Root.Element("Types").Elements("Type") select (XTypeRegistration) t.ConvertToObject<XTypeRegistration>().Instance).ToList<XTypeRegistration>();
            }
        }

        public string UserName { get; set; }

        public string Version
        {
            get
            {
                return XUtility.EngineVersion;
            }
        }
    }
}

