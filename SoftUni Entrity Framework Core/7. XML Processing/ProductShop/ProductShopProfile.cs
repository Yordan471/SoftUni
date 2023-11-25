using AutoMapper;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            // User
            this.CreateMap<ImportUserDto, User>();

            // Product
            this.CreateMap<ImportProducDto, Product>();
            this.CreateMap<Product, ExportProductDto>()
                .ForMember(epd => epd.Buyer, src =>
                src.MapFrom(p => p.Buyer.FirstName + " " + p.Buyer.LastName));

            // Category
            this.CreateMap<ImportCategoryDto, Category>();

            // CategoryProduct
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();
        }
    }
}
