using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Store.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult GenerateResponse(HttpStatusCode statusCode, object result)
            => StatusCode((int)statusCode, result);
    }
}
