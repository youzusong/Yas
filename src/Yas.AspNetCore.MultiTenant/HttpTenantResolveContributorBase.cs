using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Yas.MultiTenant;

namespace Yas.AspNetCore.MultiTenant
{
    /// <summary>
    /// 决定租户 - HTTP贡献者基类
    /// </summary>
    public abstract class HttpTenantResolveContributorBase : TenantResolveContributorBase
    {
        /// <summary>
        /// 从
        /// </summary>
        /// <param name="context"></param>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected abstract Task<string> GetTenantTokenFromHttpContextAsync(ITenantResolveContext context, HttpContext httpContext);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected virtual async Task ResolveFromHttpContextAsync(ITenantResolveContext context, HttpContext httpContext)
        {
            string tenantToken = await GetTenantTokenFromHttpContextAsync(context, httpContext);
            if (!String.IsNullOrEmpty(tenantToken))
            {
                context.TenantToken = tenantToken;
            }
        }

        public override async Task ResolveAsync(ITenantResolveContext context)
        {
            var httpContext = context.GetHttpContext();
            if (httpContext == null)
                return;

            try
            {
                await ResolveFromHttpContextAsync(context, httpContext);
            }
            catch (Exception ex)
            {
                context.ServiceProvider
                    .GetRequiredService<ILogger<HttpTenantResolveContributorBase>>()
                    .LogWarning(ex.ToString());
            }
        }
    }
}
