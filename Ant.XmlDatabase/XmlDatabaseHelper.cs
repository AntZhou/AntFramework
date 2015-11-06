namespace Ant.XmlDatabase
{
    using System.Collections.Generic;

    using global::XmlDatabase.Core;

    public class XmlDatabaseHelper
    {
        private const string DbUri = "XmlDatabase";

        public static void Save<T>(T t)
        {
            using (var db = XDatabase.Open(DbUri))
            {
                db.Store(t);
            }
        }

        public static IEnumerable<T> Query<T>()
        {
            using (var db = XDatabase.Open(DbUri))
            {
                return db.Query<T>();
            }
        }

        public static void Delete<T>(T t)
        {
            using (var db = XDatabase.Open(DbUri))
            {
                db.Delete(t);
            }
        }
    }
}