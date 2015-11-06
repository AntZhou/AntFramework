namespace XmlDatabase.Core
{
    using System;

    public class XSubmitStatus
    {
        private bool _error;
        private string _message;

        private XSubmitStatus()
        {
        }

        internal XSubmitStatus(bool error, string message)
        {
            this._error = error;
            this._message = message;
        }

        public bool HasError
        {
            get
            {
                return this._error;
            }
        }

        public string Message
        {
            get
            {
                return this._message;
            }
        }
    }
}

