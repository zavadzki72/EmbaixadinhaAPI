using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Embaixadinha.API.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class RestrictDomainAttribute : Attribute, IAuthorizationFilter
    {
        public IEnumerable<string> AllowedHosts { get; }

        public RestrictDomainAttribute(params string[] allowedHosts) => AllowedHosts = allowedHosts;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
#if !DEBUG
            string? referer = context.HttpContext.Request.Headers.Referer;
            if (!AllowedHosts.Contains(referer, StringComparer.OrdinalIgnoreCase))
            {
                context.Result = new ForbidResult($"Host is not allowed");
            }

            var userAgent = context.HttpContext.Request.Headers.UserAgent;
            if (!userAgent.Any())
            {
                context.Result = new ForbidResult($"User agent is required");
            }

            foreach(var agent in userAgent)
            {
                if (agent.Contains("postman", StringComparison.OrdinalIgnoreCase))
                {
                    context.Result = new ForbidResult($"postman requests are not allowed");
                    break;
                }
            }
#endif
        }
    }
}
