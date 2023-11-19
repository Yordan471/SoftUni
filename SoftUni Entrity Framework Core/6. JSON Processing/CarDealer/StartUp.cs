using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            // Problem 9
            //string inputJson = File.ReadAllText(@"../../../Datasets/suppliers.json");
            //string result = ImportSuppliers(context, inputJson);

            // Problem 10
            //string inputJson = File.ReadAllText(@"../../../Datasets/parts.json");
            //string result = ImportParts(context, inputJson);

            // Problem 11


            Console.WriteLine(result);
        }

        // Problem 9
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportSupplierDto[] suppliers = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);

            ICollection<Supplier> validSuppliers = new HashSet<Supplier>();

            foreach (var supplier in suppliers)
            {
                Supplier validSupplier = mapper.Map<Supplier>(supplier);

                validSuppliers.Add(validSupplier);
            }

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}.";
        }

        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportPartDto[] parts = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson);

            ICollection<Part> validParts = new HashSet<Part>();

            foreach (var part in parts)
            {
                if (!context.Suppliers.Any(s => s.Id == part.SupplierId))
                {
                    continue;
                }

                Part validPart = mapper.Map<Part>(part);

                validParts.Add(validPart);
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}.";
        }

        // Problem 11

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();


        }

        public static IMapper CreateMapper()
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            cfg.AddProfile<CarDealerProfile>()));

            return mapper;
        }
    }
}