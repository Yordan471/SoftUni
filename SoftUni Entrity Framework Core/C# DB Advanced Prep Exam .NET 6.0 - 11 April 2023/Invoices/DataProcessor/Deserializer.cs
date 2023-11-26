namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using AutoMapper;
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.DataProcessor.ImportDto;
    using Invoices.Utilities;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            string rootXmlName = "Clients";
            XmlHelper xmlHelper = new XmlHelper();

            ImportXmlClientDto[] importXmlClientDtos = 
                xmlHelper.Deserialize<ImportXmlClientDto[]>(xmlString, rootXmlName);

            ICollection<Client> validClients = new HashSet<Client>();

            StringBuilder sb = new();

            foreach (ImportXmlClientDto clientDto in importXmlClientDtos)
            {              
                if (!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client validClient = new()
                {
                    Name = clientDto.Name,
                    NumberVat = clientDto.NumberVat
                };

                foreach (var AddressDto in clientDto.Addresses)
                {
                    if (!IsValid(AddressDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Address validAddress = new()
                    {
                        StreetName = AddressDto.StreetName,
                        StreetNumber = AddressDto.StreetNumber,
                        PostCode = AddressDto.PostCode,
                        City = AddressDto.City,
                        Country = AddressDto.Country,
                    };

                    validClient.Addresses.Add(validAddress);
                }

                validClients.Add(validClient);
                sb.AppendLine(string.Format(SuccessfullyImportedClients, validClient.Name));
            }

            context.Clients.AddRange(validClients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            ImportJSONInvoicesDto[] invoiceDtos = 
                JsonConvert.DeserializeObject<ImportJSONInvoicesDto[]>(jsonString);

            ICollection<Invoice> validInvoices = new HashSet<Invoice>();
            StringBuilder sb = new();

            foreach (var invoiceDto in invoiceDtos)
            {
                if (!IsValid(invoiceDto))
                {                   
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (invoiceDto.DueDate == 
                    DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", CultureInfo.InvariantCulture) ||
                    invoiceDto.IssueDate == 
                    DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (invoiceDto.IssueDate > invoiceDto.DueDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Invoice validInvoice = new Invoice()
                {
                    Number = invoiceDto.Number,
                    IssueDate = invoiceDto.IssueDate,
                    DueDate = invoiceDto.DueDate,
                    Amount = invoiceDto.Amount,
                    ClientId = invoiceDto.ClientId
                };
              
                validInvoices.Add(validInvoice);
                sb.AppendLine(string.Format(SuccessfullyImportedInvoices, validInvoice.Number));
            }

            context.Invoices.AddRange(validInvoices);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            ImportJSONProductDto[] productDtos = JsonConvert.DeserializeObject<ImportJSONProductDto[]>(jsonString);

            ICollection<Product> validProducts = new HashSet<Product>();
            StringBuilder sb = new();

            foreach (var productDto in productDtos)
            {
                if (!IsValid(productDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Product validProduct = new()
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    CategoryType = productDto.CategoryType,
                };

                foreach (var clientId in productDto.Clients.Distinct())
                {
                    Client id = context.Clients.Find(clientId);

                    if (id == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    validProduct.ProductsClients.Add(new ProductClient()
                    {
                        Client = id
                    }); 
                }

                validProducts.Add(validProduct);
                sb.AppendLine(string.Format(SuccessfullyImportedProducts,
                    validProduct.Name, validProduct.ProductsClients.Count));
            }
            
            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();


            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        public static IMapper CreateMapper()
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            cfg.AddProfile<InvoicesProfile>()));

            return mapper;
        }
    } 
}
