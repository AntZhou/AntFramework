namespace XmlDatabase.Core
{
    using System;
    using System.Runtime.CompilerServices;

    internal class XChangeItem
    {
        public XChangeAction Action { get; set; }

        public object UserData { get; set; }
    }
}

