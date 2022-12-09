using AutoMapper;
using Store.Application._shared;
using Store.Application.Dtos.Product.Request;
using Store.Application.Dtos.Product.Response;
using Store.Application.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Interface;

namespace Store.Application.AppServices
{
    public class ProductAppService : AppService, IProductAppService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductAppService(INotifier notifier,
            IProductRepository productRepository,
            IMapper mapper) : base(notifier)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IAppServiceResponse> Create(CreateProductRequestDto request)
        {

            var newProduct = new Product(request.Name, request.Description, request.Price);

            if (newProduct.IsValid())
            {
                await _productRepository.AddAsync(newProduct);
                return new AppServiceResponse<CreateProductResponseDto>(new CreateProductResponseDto(newProduct.Id), "Product Created Successfully", true);
            }

            else
            {
                Notify(newProduct.ValidationResult);
                return new AppServiceResponse<ICollection<Notification>>(GetAllNotifications(), "Error Creating Product", false);
            }
        }

        public async Task<IAppServiceResponse> GetById(Guid Id)
        {
            var product = await _productRepository.GetAsync(Id);

            if (product == null)
            {
                Notify("Id", "Product not found");
                return new AppServiceResponse<ICollection<Notification>>(GetAllNotifications(), "Error Updating Product", false);
            }

            return new AppServiceResponse<ProductResponseDto>(_mapper.Map<ProductResponseDto>(product), "Product data", true);

        }

        public async Task<IAppServiceResponse> SearchByName(SearchProductRequestDto request)
        {
            var products = await _productRepository.SearchByNameAsync(request.Name);

            var productsDto = products != null ? _mapper.Map<IEnumerable<ProductResponseDto>>(products) : Enumerable.Empty<ProductResponseDto>();

            return new AppServiceResponse<IEnumerable<ProductResponseDto>>(productsDto, "Product contents", true);
        }

        public async Task<IAppServiceResponse> Update(UpdateProductRequestDto request, Guid id)
        {
            var product = await _productRepository.GetAsync(id);

            if (product == null)
            {
                Notify("Id", "Product not found");
                return new AppServiceResponse<ICollection<Notification>>(GetAllNotifications(), "Error Updating Product", false);
            }

            product.Update(request.Name, request.Description, request.Price);

            if (product.IsValid())
            {
                await _productRepository.Update(product);
                return new AppServiceResponse<UpdateProductResponseDto>(new UpdateProductResponseDto(product.Id, product.Name, product.Description, product.Price), "Product Updated Successfully", true);
            }
            else
            {
                return new AppServiceResponse<ICollection<Notification>>(GetAllNotifications(), "Error Updating Product", false);
            }
        }
    }
}
