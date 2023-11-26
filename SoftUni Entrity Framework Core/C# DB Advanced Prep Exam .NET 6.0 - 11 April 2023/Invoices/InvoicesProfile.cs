using AutoMapper;
using Invoices.Data.Models;
using Invoices.DataProcessor.ImportDto;

namespace Invoices
{
    public class InvoicesProfile : Profile
    {
        public InvoicesProfile()
        {
            // Invoice
            this.CreateMap<ImportJSONInvoicesDto, Invoice>();

            // Product
            this.CreateMap<ImportJSONProductDto, Product>();
        }
    }
}
