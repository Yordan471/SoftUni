namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using AutoMapper;
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.DataProcessor.ImportDto;
    using Invoices.Utilities;

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
            ICollection<Address> validAddresses = new HashSet<Address>();

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
            throw new NotImplementedException();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {


            throw new NotImplementedException();
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
