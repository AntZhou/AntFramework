namespace Ant.BaseModel
{
    using System;
    using System.Security.Cryptography.X509Certificates;

    public interface IEffective
    {
        bool IsEffective { get; set; }

        DateTime EffectiveDate { get; set; }

        DateTime FailureDate { get; set; }

    }
}