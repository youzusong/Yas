using System;
using System.Threading.Tasks;

namespace Yas.MultiTenant
{
    /// <summary>
    /// 租户仓库接口
    /// </summary>
    public interface ITenantStore
    {
        /// <summary>
        /// 通过租户名称寻找租户
        /// </summary>
        /// <param name="name">租户名称</param>
        /// <returns></returns>
        Task<TenantConfiguration> FindAsync(string name);

        /// <summary>
        /// 通过租户ID寻找租户
        /// </summary>
        /// <param name="id">租户ID</param>
        /// <returns></returns>
        Task<TenantConfiguration> FindAsync(Guid id);
    }
}
