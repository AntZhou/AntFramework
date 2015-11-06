namespace XmlDatabase.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class XIdsManager
    {
        private Dictionary<object, Guid> ids = new Dictionary<object, Guid>();
        private static Dictionary<string, XIdsManager> instances = new Dictionary<string, XIdsManager>();

        private XIdsManager()
        {
        }

        public void Clear()
        {
            this.ids.Clear();
        }

        public static XIdsManager GetInstance(string db)
        {
            if (!instances.Keys.Contains<string>(db))
            {
                instances.Add(db, new XIdsManager());
            }
            return instances[db];
        }

        public Guid GetObjectId(object o)
        {
            if (this.ids.Keys.Contains<object>(o))
            {
                return this.ids[o];
            }
            return Guid.Empty;
        }

        public void Remove(object o)
        {
            this.ids.Remove(o);
        }

        public void Set(object o, Guid id)
        {
            Func<KeyValuePair<object, Guid>, bool> func = null;
            if (this.ids.Values.Contains<Guid>(id))
            {
                if (func == null)
                {
                    func = k => k.Value == id;
                }
                this.ids.Remove(Enumerable.FirstOrDefault<KeyValuePair<object, Guid>>(this.ids, func).Key);
                this.Set(o, id);
            }
            else if (!this.ids.Keys.Contains<object>(o))
            {
                this.ids.Add(o, id);
            }
        }
    }
}

