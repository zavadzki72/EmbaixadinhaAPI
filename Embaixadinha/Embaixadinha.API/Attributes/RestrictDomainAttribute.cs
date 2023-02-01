using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Embaixadinha.API.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class RestrictDomainAttribute : Attribute, IAuthorizationFilter
    {
        public IEnumerable<string> AllowedHosts { get; }

        public RestrictDomainAttribute(params string[] allowedHosts) => AllowedHosts = allowedHosts;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string host = context.HttpContext.Request.Host.Host;
            string referer = context.HttpContext.Request.Headers.Referer;
            if (!AllowedHosts.Contains(host, StringComparer.OrdinalIgnoreCase) || !AllowedHosts.Contains(referer, StringComparer.OrdinalIgnoreCase))
            {
                context.Result = new ForbidResult($"Host is not allowed HOST: ({host}) REFERER: ({referer})");
            }
        }
    }
}
