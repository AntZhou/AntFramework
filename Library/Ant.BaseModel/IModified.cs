namespace Ant.BaseModel
{
    using System;

    /// <summary>
    /// 可修改
    /// </summary>
    public interface IModified
    {
        string ModifiedBy { get; set; }

        DateTime ModifiedOn { get; set; }
    }
}