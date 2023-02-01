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
            string? referer = context.HttpContext.Request.Headers.Referer;
            if (!AllowedHosts.Contains(referer, StringComparer.OrdinalIgnoreCase))
            {
                context.Result = new ForbidResult($"Host is not allowed");
            }

            var userAgent = context.HttpContext.Request.Headers.UserAgent;
            if(string.IsNullOrWhiteSpace(userAgent) || userAgent.Contains("postman", StringComparer.OrdinalIgnoreCase))
            {
                context.Result = new ForbidResult($"Postman requests are not allowed");
            }
        }
    }
}
