namespace XmlDatabase.Core
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml.Linq;

    internal class XLogWriter : TextWriter
    {
        private XDatabase db;
        private XDocument doc;
        private string logFile;

        internal XLogWriter(XDatabase database)
        {
            this.db = database;
            string str = Path.Combine(this.db.FullName, "SystemLogs");
            string str2 = DateTime.Now.ToString("yyyy-MM-dd");
            this.logFile = Path.Combine(str, string.Format("{0}.xml", str2));
            Directory.CreateDirectory(str);
            if (!File.Exists(this.logFile))
            {
                this.doc = new XDocument(new object[] { new XElement("XMLDatabase-SystemLogs", new object[] { new XAttribute("Date", str2), new XAttribute("EngineVersion", this.db.Version) }) });
                this.doc.Save(this.logFile);
            }
            else
            {
                this.doc = XDocument.Load(this.logFile);
            }
        }

        public override void Close()
        {
            this.doc.Save(this.logFile);
        }

        public override void Flush()
        {
            this.doc.Save(this.logFile);
        }

        public override void Write(string value)
        {
            this.WriteLine(value);
        }

        public override void WriteLine(string value)
        {
            this.doc.Root.Add(new XElement("LogEntry", new object[] { new XAttribute("Time", DateTime.Now), new XAttribute("Message", value), new XAttribute("Application", this.db.ApplicationName), new XAttribute("UserName", this.db.UserName) }));
        }

        public override System.Text.Encoding Encoding
        {
            get
            {
                return System.Text.Encoding.UTF8;
            }
        }
    }
}

