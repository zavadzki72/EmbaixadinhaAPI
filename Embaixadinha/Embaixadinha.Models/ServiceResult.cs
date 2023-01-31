using Embaixadinha.Models.Enumerators;

namespace Embaixadinha.Models
{
    public class ServiceResult
    {
        public ServiceResult(List<Notification> notifications)
        {
            Notifications = notifications;
        }

        public string? RouteLocation { get; protected set; }
        public bool Success { get; protected set; }
        public ServiceResultStatus Status { get; protected set; }
        public List<Notification> Notifications { get; protected set; }

        public static ServiceResult OkEmpty(List<Notification> notifications)
        {
            return new ServiceResult(notifications)
            {
                Status = ServiceResultStatus.OK,
                Success = true
            };
        }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public ServiceResult(List<Notification> notifications) : base(notifications) { }

        public T? Model { get; private set; }

        public static ServiceResult<T> Ok(T model, List<Notification> notifications)
        {
            return new ServiceResult<T>(notifications)
            {
                Model = model,
                Status = ServiceResultStatus.OK,
                Success = true
            };
        }

        public static ServiceResult<T> Created(string routeLocation, List<Notification> notifications)
        {
            return new ServiceResult<T>(notifications)
            {
                Model = default,
                RouteLocation = routeLocation,
                Status = ServiceResultStatus.CREATED,
                Success = true
            };
        }

        public static ServiceResult<T> Error(List<Notification> notifications)
        {
            var result = new ServiceResult<T>(notifications)
            {
                Model = default,
                Status = ServiceResultStatus.ERROR,
                Success = false
            };

            return result;
        }

        public static ServiceResult<T> NotFound(List<Notification> notifications)
        {
            var result = new ServiceResult<T>(notifications)
            {
                Model = default,
                Status = ServiceResultStatus.NOT_FOUND,
                Success = false
            };

            return result;
        }

        public static ServiceResult<T> Personalized(bool success, T model, ServiceResultStatus status, List<Notification> notifications)
        {
            var result = new ServiceResult<T>(notifications)
            {
                Model = model,
                Status = status,
                Success = success
            };

            return result;
        }
    }
}
