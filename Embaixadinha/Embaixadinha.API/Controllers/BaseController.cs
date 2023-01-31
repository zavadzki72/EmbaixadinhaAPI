using Embaixadinha.Models;
using Embaixadinha.Models.Enumerators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Embaixadinha.API.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {
        protected ActionResult ProcessResponse(ServiceResult result)
        {
            if (!result.Notifications.Any())
                return Ok();

            return Ok(new
            {
                Notifications = result.Notifications.Select(n => new
                {
                    Key = n.Key,
                    Code = n.Value
                })
            });
        }

        protected ActionResult ProcessResponse<T>(ServiceResult<T> result)
        {
            return result.Status switch
            {
                ServiceResultStatus.OK => Ok(new
                {
                    Data = result.Model,
                    Notifications = result.Notifications.Select(n => new
                    {
                        Key = n.Key,
                        Code = n.Value
                    })
                }),
                ServiceResultStatus.CREATED => Created(result.RouteLocation, null),
                ServiceResultStatus.ERROR => BadRequest(new
                {
                    Data = "error",
                    Notifications = result.Notifications.Select(n => new
                    {
                        Key = n.Key,
                        Code = n.Value
                    })
                }),
                ServiceResultStatus.NOT_FOUND => BadRequest(new
                {
                    Data = "not_found",
                    Notifications = result.Notifications.Select(n => new
                    {
                        Key = n.Key,
                        Code = n.Value
                    })
                }),
                _ => Problem(detail: "Case not mapped", statusCode: 500),
            };
        }
    }
}
