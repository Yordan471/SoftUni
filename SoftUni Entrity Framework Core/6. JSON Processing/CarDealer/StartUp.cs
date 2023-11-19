﻿using AutoMapper;
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
            //string inputJson = File.ReadAllText(@"../../../Datasets/cars.json");
            //string result = ImportCars(context, inputJson);

            // Problem 12
            //string inputJson = File.ReadAllText(@"../../../Datasets/customers.json");
            //string result = ImportCustomers(context, inputJson);

            // Problem 13
            string inputJson = File.ReadAllText(@"../../../Datasets/sales.json");
            string result = ImportSales(context, inputJson);

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

        public static IMapper CreateMapper()
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            cfg.AddProfile<CarDealerProfile>()));

            return mapper;
        }
    }
}