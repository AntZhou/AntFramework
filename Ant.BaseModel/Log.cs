namespace Ant.BaseModel
{
    using System;

    public class Log 
    {
        public string LogId { get; set; }

        public string ActionType { get; set; }

        public string DocNo { get; set; }

        public string ActionBy { get; set; }

        public DateTime ActionOn { get; set; }

        public string Description { get; set; }

    }
}