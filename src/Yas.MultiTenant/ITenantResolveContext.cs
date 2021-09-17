using Yas.Core.DependencyInjection;

namespace Yas.MultiTenant
{
    /// <summary>
    /// 决定租户 - 上下文接口
    /// </summary>
    public interface ITenantResolveContext : IServiceProviderAccessor
    {
        /// <summary>
        /// 租户标记
        /// </summary>
        string TenantToken { get; set; }

        /// <summary>
        /// 是否已处理
        /// </summary>
        bool Handled { get; set; }
    }
}
