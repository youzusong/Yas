using System;

namespace Yas.Core.Timimg
{
    /// <summary>
    /// 时间接口
    /// </summary>
    public interface ITime
    {
        /// <summary>
        /// 当前时间
        /// </summary>
        DateTime Now { get; }

        /// <summary>
        /// 时间类型
        /// </summary>
        DateTimeKind Kind { get; }

        /// <summary>
        /// 标准化时间
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <returns>标准化后的时间</returns>
        DateTime Normalize(DateTime dateTime);
    }
}
