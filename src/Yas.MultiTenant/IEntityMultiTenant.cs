using System;

namespace Yas.MultiTenant
{
    /// <summary>
    /// 多租户实体接口
    /// </summary>
    public interface IEntityMultiTenant
    {
        /// <summary>
        /// 租户ID
        /// </summary>
        Guid? TenantId { get; set; }
    }
}
