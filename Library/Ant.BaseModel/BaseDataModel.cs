namespace Ant.BaseModel
{
    using System;

    public abstract class BaseDataModel : ICreated, IModified, IEffective
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsEffective
        {
            get
            {
                return DateTime.Now >= this.EffectiveDate && DateTime.Now <= this.FailureDate;
            }
            // ReSharper disable once ValueParameterNotUsed
            set
            {
                return;
            }
        }

        public DateTime EffectiveDate { get; set; }

        public DateTime FailureDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}