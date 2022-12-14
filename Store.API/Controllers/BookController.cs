using Microsoft.AspNetCore.Mvc;
using Store.Application._shared;
using Store.Application.AppServices;
using Store.Application.Dtos.Book.Requests;
using Store.Application.Dtos.Book.Responses;
using Store.Application.Dtos.Product.Request;
using Store.Application.Dtos.Product.Response;
using Store.Application.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Store.API.Controllers
{
    /// <summary>
    /// Controller to manage book
    /// </summary>
    [Route("api/[controller]")]
    public class BookController : BaseController
    {
        private readonly IBookAppService _bookAppService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bookAppService">Service to be injected</param>
        public BookController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        /// <summary>
        /// Adds a new product using the properties supplied, returns a GUID reference for the order created
        /// </summary>
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(AppServiceResponse<string>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(AppServiceResponse<ICollection<Notification>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(AppServiceResponse<ICollection<Notification>>))]
        public async Task<IActionResult> Create([FromBody] CreateBookRequestDto request)
        {

            var result = await _bookAppService.Create(request);

            if (result.Success is false)
                return GenerateResponse(HttpStatusCode.BadRequest, result);

            return GenerateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Update a book using the properties supplied, returns all data updated
        /// </summary>
        [HttpPut("{isbn}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(AppServiceResponse<UpdateProductResponseDto>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(AppServiceResponse<ICollection<Notification>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(AppServiceResponse<ICollection<Notification>>))]
        public async Task<IActionResult> Update([FromBody] UpdateBookRequestDto request, string isbn)
        {

            var result = await _bookAppService.Update(request, isbn);

            if (result.Success is false)
                return GenerateResponse(HttpStatusCode.BadRequest, result);

            return GenerateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Delete a book
        /// </summary>
        [HttpDelete("{isbn}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(AppServiceResponse<string>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(AppServiceResponse<ICollection<Notification>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(AppServiceResponse<ICollection<Notification>>))]
        public async Task<IActionResult> Delete(string isbn)
        {

            var result = await _bookAppService.Delete(isbn);

            if (result.Success is false)
                return GenerateResponse(HttpStatusCode.BadRequest, result);

            return GenerateResponse(HttpStatusCode.OK, result);
        }


        /// <summary>
        /// GetBook
        /// </summary>
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(AppServiceResponse<IEnumerable<BookResponseDto>>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(AppServiceResponse<ICollection<Notification>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(AppServiceResponse<ICollection<Notification>>))]
        public async Task<IActionResult> Get()
        {

            var result = await _bookAppService.GetAllAsync();

            if (result.Success is false)
                return GenerateResponse(HttpStatusCode.BadRequest, result);

            return GenerateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Get a product by isbn
        /// </summary>
        [HttpGet("{isbn}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(AppServiceResponse<BookResponseDto>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(AppServiceResponse<ICollection<Notification>>))]
        public async Task<IActionResult> BetByIsbn(string isbn)
        {

            var result = await _bookAppService.GetByIsbnAsync(isbn);

            if (result.Success is false)
                return GenerateResponse(HttpStatusCode.BadRequest, result);

            return GenerateResponse(HttpStatusCode.OK, result);
        }
    }
}
