namespace Ant.BaseModel
{
    using System;

    /// <summary>
    /// 可创建
    /// </summary>
    public interface ICreated
    {
        string CreatedBy { get; set; }

        DateTime CreatedOn { get; set; }

    }
}