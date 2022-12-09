using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Store.Application._shared;
using System.Net;

namespace Store.Infra.CrossCutting
{
    public class GlobalExceptionHandlerFilter : IExceptionFilter
    {
        private readonly INotifier _notifier;

        public GlobalExceptionHandlerFilter(INotifier notifier)
        {
            _notifier = notifier;
        }

        public void OnException(ExceptionContext filterContext)
        {
            _notifier.Handle(new Notification("Oops!", "We have encountered a failure while trying to perform this operation at the moment"));

            var errorResponse = new AppServiceResponse<ICollection<Notification>>(_notifier.GetAllNotifications(), "Unexpected Error", false);

            filterContext.Result = new ObjectResult(errorResponse)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
