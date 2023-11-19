using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;

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
            //string inputJson = File.ReadAllText(@"../../../Datasets/cars.json");
            //string result = ImportCars(context, inputJson);

            // Problem 12
            //string inputJson = File.ReadAllText(@"../../../Datasets/customers.json");
            //string result = ImportCustomers(context, inputJson);

            // Problem 13
            //string inputJson = File.ReadAllText(@"../../../Datasets/sales.json");
            //string result = ImportSales(context, inputJson);

            // Problem 14
            //Console.WriteLine(GetOrderedCustomers(context));

            // Problem 15
            //Console.WriteLine(GetCarsFromMakeToyota(context));

            // Problem 16
            //Console.WriteLine(GetLocalSuppliers(context));

            // Problem 17
            Console.WriteLine(GetCarsWithTheirListOfParts(context));

            //Console.WriteLine(result);
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

            ImportCarDto[] cars = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            ICollection<Car> validCars = new HashSet<Car>();
            ICollection<PartCar> validPartCars = new HashSet<PartCar>();
            foreach (var car in cars)
            {
                Car validCar = mapper.Map<Car>(car);

                foreach (var part in car.PartsId.Distinct())
                {
                    PartCar partCar = new PartCar()
                    {
                        PartId = part,
                        Car = validCar
                    };

                    validPartCars.Add(partCar);
                }
                
                validCars.Add(validCar);
            }

            context.PartsCars.AddRange(validPartCars);
            context.Cars.AddRange(validCars);

            context.SaveChanges();

            return $"Successfully imported {validCars.Count}.";
        }

        // Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCustomerDto[] customers = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);

            ICollection<Customer> validCustomers = new HashSet<Customer>();

            foreach (var customer in customers)
            {
                Customer validCustomer = mapper.Map<Customer>(customer);

                validCustomers.Add(validCustomer);
            }

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return $"Successfully imported {validCustomers.Count}.";
        }

        // Problem 13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportSaleDto[] sales = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson);

            ICollection<Sale> validSales = new HashSet<Sale>(); 

            foreach (var sale in sales)
            {
                Sale validSale = mapper.Map<Sale>(sale);

                validSales.Add(validSale);  
            }

            context.Sales.AddRange(validSales);
            context.SaveChanges();

            return $"Successfully imported {validSales.Count}.";
        }

        // Problem 14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
                 var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver == true)
                .Select(c => new 
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    c.IsYoungDriver

                })
                .AsNoTracking()
                .AsEnumerable();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        // Problem 15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            string carToyota = "Toyota";

            var cars = context.Cars
                .Where(c => c.Make == carToyota)
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    TraveledDistance = c.TravelledDistance,
                })
                .AsNoTracking()
                .AsEnumerable();
          
            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        // Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .AsNoTracking()
                .AsEnumerable();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        //Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    parts = c.PartsCars.Select(pc => new
                    {
                        Name = pc.Part.Name,
                        Price = $"{pc.Part.Price:F2}"
                    }).ToArray()
                }).ToArray();

            var carss = context.Cars
            .Select(c => new
            {
                car = new
                {
                    c.Make,
                    c.Model,
                    TraveledDistance = c.TravelledDistance
                },
                parts = c.PartsCars.Select(cp => new
                {
                    cp.Part.Name,
                    Price = $"{cp.Part.Price:F2}"
                })
                    .AsEnumerable()
            }
            )
            .AsNoTracking()
            .AsEnumerable();
                     
            return JsonConvert.SerializeObject(cars);
        }

        public static IMapper CreateMapper()
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            cfg.AddProfile<CarDealerProfile>()));

            return mapper;
        }
    }
}