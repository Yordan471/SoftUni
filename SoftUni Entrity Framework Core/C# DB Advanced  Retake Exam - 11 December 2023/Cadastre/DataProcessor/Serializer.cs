using Cadastre.Data;
using Cadastre.Data.Enumerations;
using Cadastre.DataProcessor.ExportDtos;
using Cadastre.Utilities;
using Castle.DynamicProxy.Generators;
using Newtonsoft.Json;
using System.Globalization;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
            DateTime dateTime = DateTime.Parse("01/01/2000");
            var properties = dbContext.Properties
                .Where(p => p.DateOfAcquisition >= dateTime)
                .ToArray()
                .OrderByDescending(p => p.DateOfAcquisition)
                .ThenBy(p => p.PropertyIdentifier)
                .Select(p => new
                {
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    Address = p.Address,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Owners = p.PropertiesCitizens
                    .Where(pc => pc.Property.PropertyIdentifier == p.PropertyIdentifier)
                    .Select(pc => new
                    {
                        LastName = pc.Citizen.LastName,
                        MaritalStatus = pc.Citizen.MaritalStatus.ToString()
                    })
                    .OrderBy(c => c.LastName)
                    .ToArray()
                })
                
                .ToArray();

            return JsonConvert.SerializeObject(properties, Formatting.Indented);
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {
            int areaBiggerOrEqual100 = 100;
            var properties = dbContext.Properties
                .Where(p => p.Area >= areaBiggerOrEqual100)
                .ToArray()
                .OrderByDescending(p => p.Area)
                .ThenBy(p => p.DateOfAcquisition)
                .Select(p => new ExportXmlPropertyDto
                {
                    PostalCode = p.PropertyIdentifier.Substring(0, 8),
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                })
                .ToArray();

            XmlHelper xmlHelper = new XmlHelper();
            string xmlRootName = "Properties";

            return xmlHelper.Serializer(properties, xmlRootName);
        }
    }
}
