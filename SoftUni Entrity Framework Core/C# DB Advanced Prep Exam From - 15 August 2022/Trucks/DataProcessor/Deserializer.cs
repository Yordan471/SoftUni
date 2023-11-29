namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;
    using Trucks.Utilities;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            string xmlRootName = "Despatchers";

            XmlHelper xmlHelper = new XmlHelper();

            ImportXmlDespatcherDto[] despatcherDtos = 
                xmlHelper.Deserialize<ImportXmlDespatcherDto[]>(xmlString, xmlRootName);

            ICollection<Despatcher> validDespatchers = new HashSet<Despatcher>();
            StringBuilder sb = new();

            foreach (var despatcherDto in despatcherDtos)
            {
                if (!IsValid(despatcherDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (string.IsNullOrEmpty(despatcherDto.Position))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Despatcher validDespatcher = new()
                {
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position,
                };

                foreach (var truckDto in despatcherDto.Trucks)
                {
                    if (!IsValid(truckDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Truck validTruck = new()
                    {
                        RegistrationNumber = truckDto.RegistrationNumber,
                        VinNumber = truckDto.VinNumber,
                        TankCapacity = truckDto.TankCapacity,
                        CargoCapacity = truckDto.CargoCapacity,
                        CategoryType = (CategoryType)truckDto.CategoryType,
                        MakeType = (MakeType)truckDto.MakeType
                    };

                    validDespatcher.Trucks.Add(validTruck);

                }

                validDespatchers.Add(validDespatcher);
                sb.AppendLine($"Successfully imported despatcher – {validDespatcher.Name} with {validDespatcher.Trucks.Count} trucks.");
            }

            context.AddRange(validDespatchers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            ImportJsonClientDto[] clientDtos = JsonConvert.DeserializeObject<ImportJsonClientDto[]>(jsonString);

            ICollection<Client> validClients = new HashSet<Client>();

            StringBuilder sb = new();

            foreach (var clientDto in clientDtos)
            {
                if (!IsValid(clientDto)) 
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (clientDto.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client validClient = new()
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type,
                };

                foreach (var truckId in clientDto.Trucks.Distinct())
                {
                    Truck existingTruck = context.Trucks.Find(truckId);

                    if (existingTruck == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    validClient.ClientsTrucks.Add(new ClientTruck
                    {
                        TruckId = truckId
                    });
                }

                validClients.Add(validClient);
                sb.AppendLine($"Successfully imported client - {validClient.Name} with {validClient.ClientsTrucks.Count} trucks.");
            }

            context.Clients.AddRange(validClients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}