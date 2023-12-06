namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ImportDtos;
    using Medicines.Utilities;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            ImportJsonPatientDto[] patientDtos = JsonConvert.DeserializeObject<ImportJsonPatientDto[]>(jsonString);

            ICollection<Patient> validPatients = new HashSet<Patient>();
            StringBuilder sb = new StringBuilder();

            foreach (var patientDto in patientDtos)
            {
                if (!IsValid(patientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Patient validPatient = new Patient()
                {
                    FullName = patientDto.FullName,
                    AgeGroup = (AgeGroup)patientDto.AgeGroup,
                    Gender = (Gender)patientDto.Gender
                };

                foreach (var medicineId in patientDto.Medicines)
                {
                    //Medicine existingMedicine = context.Medicines.Find(medicineId);

                    if (validPatient.PatientsMedicines.Any(pm => pm.MedicineId == medicineId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    };

                    PatientMedicine patientMedicine = new PatientMedicine()
                    {
                        Patient = validPatient,
                        MedicineId = medicineId
                    };

                    validPatient.PatientsMedicines.Add(patientMedicine);
                }

                validPatients.Add(validPatient);
                sb.AppendLine(string.Format(
                    SuccessfullyImportedPatient, validPatient.FullName, validPatient.PatientsMedicines.Count));
            }

            context.Patients.AddRange(validPatients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();   
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            string xmlRootName = "Pharmacies";

            ImportXmlPharmacyDto[] pharmacyDtos = xmlHelper.Deserialize<ImportXmlPharmacyDto[]>(xmlString, xmlRootName);

            ICollection<Pharmacy> validPharmacies = new HashSet<Pharmacy>();
            StringBuilder sb = new();

            foreach (var pharmacyDto in pharmacyDtos)
            {
                if (!IsValid(pharmacyDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool boolean;
                bool isBoolean = bool.TryParse(pharmacyDto.IsNonStop, out boolean);
                
                if (!isBoolean)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Pharmacy validPharmacy = new Pharmacy()
                {
                    Name = pharmacyDto.Name,
                    IsNonStop = boolean,
                    PhoneNumber = pharmacyDto.PhoneNumber,
                };

                foreach (var medicine in pharmacyDto.Medicines)
                {
                    if (!IsValid(medicine))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime medicineProductionDate;
                    bool isMedicineProductionDate = DateTime.TryParseExact(medicine.ProductionDate,
                        "yyyy-MM-dd", CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out medicineProductionDate);
                    if (!isMedicineProductionDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime medicineExpiryDate;
                    bool isMedicineExpiryDate = DateTime.TryParseExact(medicine.ExpiryDate,
                        "yyyy-MM-dd", CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out medicineExpiryDate);
                    if (!isMedicineProductionDate || !isMedicineExpiryDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (medicineProductionDate >= medicineExpiryDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Medicine validMedicine = new()
                    {
                        Name = medicine.Name,
                        Price = medicine.Price,
                        ProductionDate = medicineProductionDate,
                        ExpiryDate = medicineExpiryDate,
                        Producer = medicine.Producer,
                        Category = (Category)medicine.Category,
                    };

                    Medicine isTrue = 
                        validPharmacy.Medicines.FirstOrDefault(m => m.Name == validMedicine.Name && m.Producer == validMedicine.Producer);
                    if (!(isTrue == null))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    validPharmacy.Medicines.Add(validMedicine);
                }

                validPharmacies.Add(validPharmacy);
                sb.AppendLine(string.Format(SuccessfullyImportedPharmacy, validPharmacy.Name, validPharmacy.Medicines.Count));
            }

            context.Pharmacies.AddRange(validPharmacies);
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
