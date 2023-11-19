using AutoMapper;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            // Supplier
            this.CreateMap<ImportSupplierDto, Supplier>();

            // Parts
            this.CreateMap<ImportPartDto, Part>();

            // Cars
            this.CreateMap<ImportCarDto, Car>();

            // Customer
            this.CreateMap<ImportCustomerDto, Customer>();
        }
    }
}
