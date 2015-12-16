namespace Ant.BaseModel
{
    using System;

    public interface IClosed
    {
        bool Closed { get; set; }

        string ClosedBy { get; set; }

        DateTime ClosedOn { get; set; }

        string ClosedReason { get; set; }
    }
}