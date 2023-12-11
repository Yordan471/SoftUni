namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using Cadastre.Data.Enumerations;
    using Cadastre.Data.Models;
    using Cadastre.DataProcessor.ImportDtos;
    using Cadastre.Utilities;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Threading;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            XmlHelper xmlHelper = new XmlHelper();
            string xmlRootName = "Districts";

            ImportXmlDistrictDto[] districtDtos = 
                xmlHelper.Deserialize<ImportXmlDistrictDto[]>(xmlDocument, xmlRootName);

            ICollection<District> validDistricts = new HashSet<District>();
            StringBuilder sb = new();

            foreach (var districtDto in districtDtos)
            {
                if (!IsValid(districtDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                District validDistrict = 
                    validDistricts.FirstOrDefault(d => d.Name == districtDto.Name);

                if (validDistrict != null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validDistrict = new()
                {
                    Name = districtDto.Name,
                    PostalCode = districtDto.PostalCode,
                    Region = Enum.Parse<Region>(districtDto.Region)
                };

                foreach (var propertyDto in districtDto.Properties)
                {
                    if (!IsValid(propertyDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (propertyDto.Area < 0)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime parseDateOfAcquisition;
                    bool isValidBoolDateOfAcquisition = DateTime.TryParseExact(
                        propertyDto.DateOfAcquisition,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out parseDateOfAcquisition);

                    if (!isValidBoolDateOfAcquisition)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (validDistrict.Properties.Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier ||
                        validDistricts.Any(d => d.Properties.Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier))))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (validDistrict.Properties.Any(p => p.Address == propertyDto.Address ||
                        validDistricts.Any(d => d.Properties.Any( p => p.Address == propertyDto.Address))))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Property validProperty = new()
                    {
                        PropertyIdentifier = propertyDto.PropertyIdentifier,
                        Area = propertyDto.Area,
                        Details = propertyDto.Details,
                        Address = propertyDto.Address,
                        DateOfAcquisition = parseDateOfAcquisition
                    };

                    validDistrict.Properties.Add(validProperty);                    
                }

                validDistricts.Add(validDistrict);
                sb.AppendLine(string.Format(SuccessfullyImportedDistrict, validDistrict.Name, validDistrict.Properties.Count));
            }

            dbContext.Districts.AddRange(validDistricts);
            dbContext.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            ImportJsonCitizenDto[] citizenDtos = 
                JsonConvert.DeserializeObject<ImportJsonCitizenDto[]>(jsonDocument);

            ICollection<Citizen> validCitizens = new HashSet<Citizen>();
            StringBuilder sb = new StringBuilder();
            string[] maritalStatusArr = new string[] { "Unmarried", "Married", "Divorced", "Widowed" };

            foreach (var citizenDto in citizenDtos)
            {
                if (!IsValid(citizenDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!maritalStatusArr.Contains(citizenDto.MaritalStatus))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime parseBirthDate;
                bool isValidBirthDate = DateTime.TryParseExact(
                    citizenDto.BirthDate,
                    "dd-MM-yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out parseBirthDate);

                if (!isValidBirthDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Citizen validCitizen = new()
                {
                    FirstName = citizenDto.FirstName,
                    LastName = citizenDto.LastName,
                    BirthDate = parseBirthDate,
                    MaritalStatus = Enum.Parse<MaritalStatus>(citizenDto.MaritalStatus)
                };

                foreach (var propertyId in citizenDto.Properties)
                {
                    validCitizen.PropertiesCitizens.Add(new PropertyCitizen
                    {
                        PropertyId = propertyId
                    });
                }

                validCitizens.Add(validCitizen);
                sb.AppendLine(string.Format(
                    SuccessfullyImportedCitizen, validCitizen.FirstName, validCitizen.LastName, validCitizen.PropertiesCitizens.Count));
            }

            dbContext.Citizens.AddRange(validCitizens);
            dbContext.SaveChanges();

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
