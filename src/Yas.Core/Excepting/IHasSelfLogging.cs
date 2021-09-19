using Microsoft.Extensions.Logging;

namespace Yas.Core.Excepting
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHasSelfLogging
    {
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="logger"></param>
        void SelfLog(ILogger logger);
    }
}
