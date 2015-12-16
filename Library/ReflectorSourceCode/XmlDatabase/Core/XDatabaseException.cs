namespace XmlDatabase.Core
{
    using System;
    using System.Text;
    using XmlDatabase.Core.Properties;

    public class XDatabaseException : Exception
    {
        private string message;

        private XDatabaseException()
        {
        }

        public XDatabaseException(string key, params string[] place)
        {
            StringBuilder builder = new StringBuilder(Resources.ResourceManager.GetString(key));
            if (place.Length > 0)
            {
                int num = 0;
                foreach (string str in place)
                {
                    builder.Replace("{" + num++ + "}", str);
                }
            }
            this.message = builder.ToString();
        }

        public override string Message
        {
            get
            {
                return this.message;
            }
        }
    }
}

