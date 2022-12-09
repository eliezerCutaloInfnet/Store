using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Store.Application._shared;
using Store.Application.Dtos.Product.Request;
using Store.Application.Dtos.Product.Response;
using Store.Application.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        /// <summary>
        /// Adds a new product using the properties supplied, returns a GUID reference for the order created
        /// </summary>
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(AppServiceResponse<CreateProductResponseDto>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(AppServiceResponse<ICollection<Notification>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(AppServiceResponse<ICollection<Notification>>))]
        public async Task<IActionResult> Create([FromBody] CreateProductRequestDto request)
        {

            var result = await _productAppService.Create(request);

            if (result.Success is false)
                return GenerateResponse(HttpStatusCode.BadRequest, result);

            return GenerateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Update a product using the properties supplied, returns all data updated
        /// </summary>
        [HttpPut("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(AppServiceResponse<UpdateProductResponseDto>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(AppServiceResponse<ICollection<Notification>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(AppServiceResponse<ICollection<Notification>>))]
        public async Task<IActionResult> Update([FromBody] UpdateProductRequestDto request, Guid id)
        {

            var result = await _productAppService.Update(request, id);

            if (result.Success is false)
                return GenerateResponse(HttpStatusCode.BadRequest, result);

            return GenerateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Get a product by Id
        /// </summary>
        [HttpGet("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(AppServiceResponse<ProductResponseDto>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(AppServiceResponse<ICollection<Notification>>))]
        public async Task<IActionResult> Update([FromRoute]  Guid id)
        {

            var result = await _productAppService.GetById(id);

            if (result.Success is false)
                return GenerateResponse(HttpStatusCode.BadRequest, result);

            return GenerateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Search product by name
        /// </summary>
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(AppServiceResponse<IEnumerable<ProductResponseDto>>))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(AppServiceResponse<ICollection<Notification>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Type = typeof(AppServiceResponse<ICollection<Notification>>))]
        public async Task<IActionResult> Search([FromQuery] SearchProductRequestDto requestDto)
        {

            var result = await _productAppService.SearchByName(requestDto);

            if (result.Success is false)
                return GenerateResponse(HttpStatusCode.BadRequest, result);

            return GenerateResponse(HttpStatusCode.OK, result);
        }
    }
}
