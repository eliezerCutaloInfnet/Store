using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Store.API.Controllers
{
    /// <summary>
    /// Base controller
    /// </summary>
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Generate response
        /// </summary>
        /// <param name="statusCode">Http Status code</param>
        /// <param name="result">the result</param>
        /// <returns></returns>
        protected IActionResult GenerateResponse(HttpStatusCode statusCode, object result)
            => StatusCode((int)statusCode, result);
    }
}
