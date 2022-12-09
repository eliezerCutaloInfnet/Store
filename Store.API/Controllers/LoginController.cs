using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Store.Application._shared;
using Store.Application.Dtos.Login.Request;
using Store.Application.Dtos.Login.Response;
using Store.Application.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : BaseController
    {
        #region Private Fields

        private readonly ILoginAppService _loginService;

        #endregion Private Fields

        #region Public Constructors

        public LoginController(ILoginAppService loginService)
        {
            _loginService = loginService;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Adds a new user using the properties supplied, returns a GUID reference for the user created
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("signup")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(AppServiceResponse<SignUpResponseDto>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(AppServiceResponse<ICollection<Notification>>))]
        [SwaggerResponse((int) HttpStatusCode.InternalServerError, Type = typeof(AppServiceResponse<ICollection<Notification>>))]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequestDto request)
        {

            var result = await _loginService.SignUp(request);

            if (result.Success is false)
                return GenerateResponse(HttpStatusCode.BadRequest, result);

            return GenerateResponse(HttpStatusCode.OK, result);
        }

        #endregion Public Methods
    }
}
