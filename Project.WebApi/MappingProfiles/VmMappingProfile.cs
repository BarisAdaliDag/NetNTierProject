using AutoMapper;
using Project.Bll.Dtos;
using Project.WebApi.Models.RequestModels.AppUser;
using Project.WebApi.Models.RequestModels.AppUserProfile;
using Project.WebApi.Models.RequestModels.Categories;
using Project.WebApi.Models.RequestModels.Order;
using Project.WebApi.Models.RequestModels.OrderDetail;
using Project.WebApi.Models.RequestModels.Product;
using Project.WebApi.Models.ResponseModels.AppUser;
using Project.WebApi.Models.ResponseModels.AppUserProfile;
using Project.WebApi.Models.ResponseModels.Categories;
using Project.WebApi.Models.ResponseModels.Order;
using Project.WebApi.Models.ResponseModels.OrderDetail;
using Project.WebApi.Models.ResponseModels.Product;

namespace Project.WebApi.MappingProfiles
{
    public class VmMappingProfile : Profile
    {
        public VmMappingProfile()
        {


            CreateMap<CreateCategoryRequestModel, CategoryDto>();
            CreateMap<UpdateCategoryRequestModel, CategoryDto>();
            CreateMap<CategoryDto, CategoryResponseModel>();

            CreateMap<CreateProductRequestModel, ProductDto>();
            CreateMap<UpdateProductRequestModel, ProductDto>();
            CreateMap<ProductDto, ProductResponseModel>();

            // AppUser Mappings
            CreateMap<CreateAppUserRequestModel, AppUserDto>();
            CreateMap<UpdateAppUserRequestModel, AppUserDto>();
            CreateMap<AppUserDto, AppUserResponseModel>();

            // AppUserProfile Mappings
            CreateMap<CreateAppUserProfileRequestModel, AppUserProfileDto>();
            CreateMap<UpdateAppUserProfileRequestModel, AppUserProfileDto>();
            CreateMap<AppUserProfileDto, AppUserProfileResponseModel>();

            // Order Mappings
            CreateMap<CreateOrderRequestModel, OrderDto>();
            CreateMap<UpdateOrderRequestModel, OrderDto>();
            CreateMap<OrderDto, OrderResponseModel>();

            // OrderDetail Mappings
            CreateMap<CreateOrderDetailRequestModel, OrderDetailDto>();
            CreateMap<UpdateOrderDetailRequestModel, OrderDetailDto>();
            CreateMap<OrderDetailDto, OrderDetailResponseModel>();
        }
    }
}
