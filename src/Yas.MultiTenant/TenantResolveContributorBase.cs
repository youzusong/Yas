using System.Threading.Tasks;

namespace Yas.MultiTenant
{
    /// <summary>
    /// 决定租户 - 贡献者基类
    /// </summary>
    public abstract class TenantResolveContributorBase : ITenantResolveContributor
    {
        public abstract string Name { get; }

        public abstract Task ResolveAsync(ITenantResolveContext context);
    }
}
