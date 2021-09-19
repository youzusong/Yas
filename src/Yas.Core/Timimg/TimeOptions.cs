using System;

namespace Yas.Core.Timimg
{
    /// <summary>
    /// 时间配置项
    /// </summary>
    public class TimeOptions
    {
        /// <summary>
        /// 时间类型
        /// </summary>
        public DateTimeKind Kind { get; set; }

        public TimeOptions()
        {
            Kind = DateTimeKind.Unspecified;
        }
    }
}
