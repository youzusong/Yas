using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Yas.Core.DependencyInjection;

namespace Yas
{
    public static class ServiceProviderAccessorExtensions
    {
        public static HttpContext GetHttpContext(this IServiceProviderAccessor serviceProviderAccessor)
        {
            return serviceProviderAccessor.ServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
        }
    }
}
