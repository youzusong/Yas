using System.Threading.Tasks;

namespace Yas.MultiTenant
{
    /// <summary>
    /// 决定租户 - 贡献者接口
    /// </summary>
    public interface ITenantResolveContributor
    {
        /// <summary>
        /// 贡献者名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 决定租户
        /// </summary>
        /// <param name="context">上下文</param>
        /// <returns></returns>
        Task ResolveAsync(ITenantResolveContext context);
    }
}
