namespace Ant.BaseModel
{
    using System;

    public interface IApproved
    {
        string ApprovedBy { get; set; }

        DateTime ApprovedOn { get; set; }

        bool ApproveResult { get; set; }

        string ApprovedReason { get; set; }
    }
}