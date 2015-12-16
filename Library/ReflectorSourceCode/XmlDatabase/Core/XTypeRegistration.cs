namespace XmlDatabase.Core
{
    using System;
    using System.Runtime.CompilerServices;

    public class XTypeRegistration
    {
        private int rowCount = 0x3e8;
        private bool singleRow;

        public string FullName { get; set; }

        public int RowCountPerFile
        {
            get
            {
                return this.rowCount;
            }
            set
            {
                this.rowCount = value;
            }
        }

        public bool SingleRowPerFile
        {
            get
            {
                return this.singleRow;
            }
            set
            {
                this.singleRow = value;
            }
        }
    }
}

