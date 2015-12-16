namespace XmlDatabase.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class XBufferManager
    {
        private static Dictionary<string, XBufferManager> instances = new Dictionary<string, XBufferManager>();

        private XBufferManager()
        {
        }

        public static XBufferManager GetInstance(string db)
        {
            if (!instances.Keys.Contains<string>(db))
            {
                instances.Add(db, new XBufferManager());
            }
            return instances[db];
        }
    }
}

