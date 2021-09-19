using System;

namespace Yas.Core.Uid
{
    /// <summary>
    /// GUID产生器
    /// </summary>
    public interface IGuidGenerator
    {
        /// <summary>
        /// 产生GUID
        /// </summary>
        /// <returns></returns>
        Guid Create();
    }
}
