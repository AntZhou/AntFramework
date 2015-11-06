namespace XmlDatabase.Core
{
    using System;

    public class XTransaction
    {
        private XDatabase database;

        private XTransaction()
        {
        }

        internal XTransaction(XDatabase db)
        {
            this.database = db;
        }
    }
}

