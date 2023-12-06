namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.DataProcessor.ImportDto;
    using Artillery.Utilities;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            XmlHelper xmlHelper = new();
            string xmlRootName = "Countries";

            ImportXmlCountryDto[] countryDtos = xmlHelper.Deserialize<ImportXmlCountryDto[]>(xmlString, xmlRootName);

            ICollection<Country> validCountries = new HashSet<Country>();
            StringBuilder sb = new();

            foreach (var countryDto in countryDtos)
            {
                if (!IsValid(countryDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Country validCountry = new Country()
                {
                    CountryName = countryDto.CountryName,
                    ArmySize = countryDto.ArmySize,
                };

                validCountries.Add(validCountry);
                sb.AppendLine(string.Format(SuccessfulImportCountry, validCountry.CountryName, validCountry.ArmySize));
            }

            context.Countries.AddRange(validCountries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            XmlHelper xmlHelper = new();
            string xmlRootName = "Manufacturers";

            ImportXmlManufacturerDto[] manufacturerDtos =
                xmlHelper.Deserialize<ImportXmlManufacturerDto[]>(xmlString, xmlRootName);

            ICollection<Manufacturer> validManufacturers = new HashSet<Manufacturer>();
            StringBuilder sb = new();

            foreach (var manufacturerDto in manufacturerDtos.Distinct())
            {
                if (!IsValid(manufacturerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Manufacturer validManufacturer = new Manufacturer()
                {
                    ManufacturerName = manufacturerDto.ManufacturerName,
                    Founded = manufacturerDto.Founded
                };

                string[] foundedArr = validManufacturer.Founded.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string townName = foundedArr[foundedArr.Length - 2];
                string countryName = foundedArr[foundedArr.Length - 1];

                validManufacturers.Add(validManufacturer);
                sb.AppendLine(string.Format(
                    SuccessfulImportManufacturer, validManufacturer.ManufacturerName, townName, countryName));
            }

            context.Manufacturers.AddRange(validManufacturers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            string xmlRootName = "Shells";

            ImportXmlShellDto[] shellDtos = xmlHelper.Deserialize<ImportXmlShellDto[]>(xmlString, xmlRootName);

            ICollection<Shell> validShells = new HashSet<Shell>();
            StringBuilder sb = new();

            foreach (var shellDto in shellDtos)
            {
                if (!IsValid(shellDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Shell validShell = new()
                {
                    ShellWeight = shellDto.ShellWeight,
                    Caliber = shellDto.Caliber
                };

                validShells.Add(validShell);
                sb.AppendLine(string.Format(SuccessfulImportShell, validShell.Caliber, validShell.ShellWeight));
            }

            context.Shells.AddRange(validShells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}