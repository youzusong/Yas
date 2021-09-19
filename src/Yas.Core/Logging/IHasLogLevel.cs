using Microsoft.Extensions.Logging;

namespace Yas.Core.Logging
{
    /// <summary>
    /// 拥有日志等级接口
    /// </summary>
    public interface IHasLogLevel
    {
        /// <summary>
        /// 日志等级
        /// </summary>
        LogLevel LogLevel { get; set; }
    }
}
