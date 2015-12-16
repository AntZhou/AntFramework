namespace XmlDatabase.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using XmlDatabase.Core.Properties;

    internal class XTaskManager
    {
        private Dictionary<string, XDocument> docs;
        private Dictionary<string, FileStream> fs;
        private XDatabase internaldb;
        private List<XChangeItem> tasks;

        private XTaskManager()
        {
            this.tasks = new List<XChangeItem>();
        }

        public XTaskManager(XDatabase db)
        {
            this.tasks = new List<XChangeItem>();
            this.internaldb = db;
        }

        private void AddOrUpdateObject(object o)
        {
            Func<XElement, bool> func = null;
            string fullName = o.GetType().FullName;
            string name = o.GetType().Name;
            string path = string.Format(@"{4}\{0}\{1}\{2}\{3}.xml", new object[] { "Entities", fullName, "Data", fullName, this.internaldb.FullName });
            if (File.Exists(path))
            {
                if (!this.fs.Keys.Contains<string>(path))
                {
                    FileStream stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                    this.fs.Add(path, stream);
                    this.docs.Add(path, XDocument.Load(new StreamReader(stream)));
                }
            }
            else
            {
                XDocument document = new XDocument(new object[] { new XElement("XMLDatabase-Entities") });
                document.Save(path);
                this.docs.Add(path, document);
                this.fs.Add(path, new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None));
            }
            XDocument document2 = this.docs[path];
            Guid id = this.internaldb.ids.GetObjectId(o);
            if (id != Guid.Empty)
            {
                if (func == null)
                {
                    func = e => e.Attribute("_uuid").Value == id.ToString();
                }
                XElement element = Enumerable.Where<XElement>(document2.Root.Elements(name), func).FirstOrDefault<XElement>();
                XElement content = o.ConvertToXml(id);
                element.ReplaceWith(content);
                this.internaldb.Log.WriteEx(string.Format(Resources.UpdateObject, id, o.ToString()));
            }
            else
            {
                id = Guid.NewGuid();
                XElement element3 = o.ConvertToXml(id);
                document2.Root.Add(element3);
                this.internaldb.Log.WriteEx(string.Format(Resources.InsertObject, id, o.ToString()));
            }
        }

        public void AddTask(XChangeItem task)
        {
            this.tasks.Add(task);
        }

        private void DeleteObject(object o)
        {
            Guid id = this.internaldb.ids.GetObjectId(o);
            string fullName = o.GetType().FullName;
            string name = o.GetType().Name;
            string path = string.Format(@"{4}\{0}\{1}\{2}\{3}.xml", new object[] { "Entities", fullName, "Data", fullName, this.internaldb.FullName });
            if ((id == Guid.Empty) || !File.Exists(path))
            {
                throw new XDatabaseException("DeleteObjectError", new string[] { o.ToString() });
            }
            if (!this.fs.Keys.Contains<string>(path))
            {
                FileStream stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                this.fs.Add(path, stream);
                this.docs.Add(path, XDocument.Load(new StreamReader(stream)));
            }
            XDocument document = this.docs[path];
            XElement element = (from e in document.Root.Elements()
                where e.Attribute("_uuid").Value == id.ToString()
                select e).FirstOrDefault<XElement>();
            if (element != null)
            {
                element.Remove();
            }
            this.internaldb.ids.Remove(o);
            this.internaldb.Log.WriteEx(string.Format(Resources.DeleteObject, id, o));
        }

        public XSubmitStatus Execute(bool continueOnError, bool hasTransaction)
        {
            StringBuilder builder = new StringBuilder();
            bool error = false;
            this.fs = new Dictionary<string, FileStream>();
            this.docs = new Dictionary<string, XDocument>();
            foreach (XChangeItem item in this.tasks)
            {
                try
                {
                    switch (item.Action)
                    {
                        case XChangeAction.AddOrUpdate:
                        {
                            this.AddOrUpdateObject(item.UserData);
                            continue;
                        }
                        case XChangeAction.Delete:
                        {
                            this.DeleteObject(item.UserData);
                            continue;
                        }
                        case XChangeAction.Clear:
                        {
                            continue;
                        }
                    }
                }
                catch (Exception exception)
                {
                    error = true;
                    builder.AppendFormat(Resources.ChangeActionError, item.UserData.ToString(), item.Action, exception.Message);
                    builder.AppendLine();
                    if (!continueOnError)
                    {
                        break;
                    }
                }
            }
            foreach (KeyValuePair<string, FileStream> pair in this.fs)
            {
                pair.Value.Close();
            }
            if (!error || !hasTransaction)
            {
                foreach (KeyValuePair<string, XDocument> pair2 in this.docs)
                {
                    pair2.Value.Save(pair2.Key);
                }
            }
            this.fs.Clear();
            this.docs.Clear();
            this.tasks.Clear();
            this.internaldb.Log.Flush();
            return new XSubmitStatus(error, builder.ToString());
        }
    }
}

