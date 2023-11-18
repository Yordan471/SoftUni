﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            // Users
            //string inputJson = File.ReadAllText(@"../../../Datasets/users.json");
            //string result = ImportUsers(context, inputJson);

            // Products
            //string inputJson = File.ReadAllText(@"../../../Datasets/products.json");
            //string result = ImportProducts(context, inputJson);

            // Category
            //string inputJson = File.ReadAllText(@"../../../Datasets/categories.json");
            //string result = ImportCategories(context, inputJson);

            // CategoryProduct
            //string inputJson = File.ReadAllText(@"../../../Datasets/categories-products.json");
            //string result = ImportCategoryProducts(context, inputJson);

            Console.WriteLine(GetProductsInRange(context));

            //Console.WriteLine(result);
        }

        public static IMapper MappingMethod()
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            cfg.AddProfile<ProductShopProfile>()));

            return mapper;
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IMapper mapper = MappingMethod();

            ImportUserDto[] userDtos = 
                JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            ICollection<User> validUsers = new HashSet<User>();

            foreach (ImportUserDto user in userDtos)
            {
                User validUser = mapper.Map<User>(user);

                validUsers.Add(validUser);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = MappingMethod();

            ImportProductDto[] productDtos =
                JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);

            ICollection<Product> validProducts = new HashSet<Product>();

            foreach (var productDto in productDtos)
            {
                Product validProduct = mapper.Map<Product>(productDto);

                validProducts.Add(validProduct);
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IMapper mapper = MappingMethod();

            ImportCategoryDto[] categoryDtos = 
                JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);

            ICollection<Category> validCategories = new HashSet<Category>();

            foreach (var categoryDto in categoryDtos)
            {
                if (categoryDto.Name == null)
                {
                    continue;
                }

                Category validCategory = mapper.Map<Category>(categoryDto);

                validCategories.Add(validCategory);
            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = MappingMethod();

            ImportCategoryProductDto[] categoryProductDtos = 
                JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            ICollection<CategoryProduct> validCategoryProductDtos = new HashSet<CategoryProduct>();

            foreach (var categoryProduct in categoryProductDtos)
            {
                if (!context.Categories.Any(c => c.Id == categoryProduct.CategoryId) ||
                    !context.Products.Any(p => p.Id == categoryProduct.ProductId))
                {
                    continue;
                }

                CategoryProduct validCategoryProduct = mapper.Map<CategoryProduct>(categoryProduct);

                validCategoryProductDtos.Add(validCategoryProduct);
            }

            context.CategoriesProducts.AddRange(validCategoryProductDtos);
            context.SaveChanges();

            return $"Successfully imported {validCategoryProductDtos.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName,
                })
                .AsNoTracking()
                .AsEnumerable();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }
    }
}