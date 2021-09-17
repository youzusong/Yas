using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Yas.Core.Text.Formatting;
using Yas.MultiTenant;

namespace Yas.AspNetCore.MultiTenant
{
    public class DomainTenantResolveContributor : HttpTenantResolveContributorBase
    {
        private static readonly string[] _protocolPrefixes = { "http://", "https://" };
        private readonly string _domainFormat;

        public DomainTenantResolveContributor(string domainFormat)
        {
            _domainFormat = domainFormat;
        }

        public override string Name => "Domain";

        protected override Task<string> GetTenantTokenFromHttpContextAsync(ITenantResolveContext context, HttpContext httpContext)
        {
            if (!httpContext.Request.Host.HasValue)
                return Task.FromResult<string>(null);

            var hostName = httpContext.Request.Host.Value.RemovePreFix(_protocolPrefixes);
            var extractResult = FormatStringValueExtracter.Extract(hostName, _domainFormat, ignoreCase: true);

            context.Handled = true;

            return Task.FromResult(extractResult.IsMatch ? extractResult.Matches[0].Value : null);
        }
    }
}
