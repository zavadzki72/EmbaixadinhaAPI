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
            if (!AllowedHosts.Contains(host, StringComparer.OrdinalIgnoreCase))
            {
                context.Result = new ForbidResult($"Host {host} is not allowed");
            }
        }
    }
}
