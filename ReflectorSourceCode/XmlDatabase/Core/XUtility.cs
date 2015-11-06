namespace XmlDatabase.Core
{
    using System;

    internal class XUtility
    {
        private XUtility()
        {
        }

        public static string EngineVersion
        {
            get
            {
                return typeof(XUtility).Assembly.GetName().Version.ToString();
            }
        }
    }
}

