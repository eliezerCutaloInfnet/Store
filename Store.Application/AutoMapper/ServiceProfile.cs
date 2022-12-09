using AutoMapper;
using Store.Application.Dtos.Product.Response;
using Store.Domain.Entities;

namespace Store.Application.AutoMapper
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Product, ProductResponseDto>();
        }
    }
}
