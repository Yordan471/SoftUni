namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ExportDtos;
    using Medicines.Utilities;
    using Newtonsoft.Json;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            DateTime afterDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            var patients = context.Patients
                .Where(p => p.PatientsMedicines.Any(pm => pm.Medicine.ProductionDate > afterDate))
                .ToArray()
                .Select(p => new ExportXmlPatientsDto()
                {
                    Name = p.FullName,
                    Gender = p.Gender.ToString().ToLower(),
                    AgeGroup = p.AgeGroup.ToString(),
                    Medicines = p.PatientsMedicines
                    .Where(pm => pm.Medicine.ProductionDate > afterDate)
                    .OrderByDescending(m => m.Medicine.ExpiryDate)
                    .ThenBy(m => m.Medicine.Price)
                    .Select(pm => new ExportXmlMedicinesDto()
                    {
                        Name = pm.Medicine.Name,
                        Category = pm.Medicine.Category.ToString().ToLower(),
                        Price = pm.Medicine.Price.ToString("F2"),
                        Producer = pm.Medicine.Producer,
                        BestBefore = pm.Medicine.ExpiryDate.ToString("yyyy-MM-dd")
                    })                 
                    .ToArray()
                })
                .OrderByDescending(p => p.Medicines.Length)
                .ThenBy(p => p.Name)
                .ToArray();   

            XmlHelper xmlHelper = new XmlHelper();
            string xmlRootName = "Patients";

            return xmlHelper.Serializer(patients, xmlRootName);
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            Category category = (Category)medicineCategory;
            var medicines = context.Medicines
                .Where(m => m.Category == category && m.Pharmacy.IsNonStop == true)
                .ToArray()
                .Select(m => new 
                {
                    Name = m.Name,
                    Price = m.Price.ToString("F2"),
                    Pharmacy = new
                    {
                        m.Pharmacy.Name,
                        m.Pharmacy.PhoneNumber
                    }                   
                })
                .OrderBy(m => m.Price)
                .ThenBy(m => m.Name)
                .ToArray();
                
            return JsonConvert.SerializeObject(medicines, Formatting.Indented);
        }
    }
}
