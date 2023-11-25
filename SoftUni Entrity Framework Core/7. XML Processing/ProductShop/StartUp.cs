using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            // Problem 1
            //string inputXml = File.ReadAllText(@"../../../Datasets/users.xml");
            //string result = ImportUsers(context, inputXml);

            // Problem 2
            string inputXml = File.ReadAllText(@"../../../Datasets/products.xml");
            string result = ImportProducts(context, inputXml);

            // Problem 3
            //string inputXml = File.ReadAllText(@"../../../Datasets/categories.xml");
            //string result = ImportCategories(context, inputXml);

            // Problem 4
            //string inputXml = File.ReadAllText(@"../../../Datasets/categories-products.xml");
            //string result = ImportCategoryProducts(context, inputXml);

            // Problem 5
            //Console.WriteLine(GetProductsInRange(context));

            Console.WriteLine(result);
        }

        // Problem 1
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            string xmlRootName = "Users";

            XmlHelper xmlHelper = new();
            ImportUserDto[] importUsers = xmlHelper.Deserialize<ImportUserDto[]>(inputXml, xmlRootName);

            ICollection<User> validUsers = new HashSet<User>();

            IMapper userMapper = CreateMapper();

            foreach (var userDto in importUsers)
            {
                User validUser = userMapper.Map<User>(userDto);

                validUsers.Add(validUser);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        // Problem 2
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            string rootName = "Products";

            IMapper mapper = CreateMapper();

            XmlHelper xmlHelper = new();

            ImportProducDto[] importedProductDtos = 
                xmlHelper.Deserialize<ImportProducDto[]>(inputXml, rootName);

            ICollection<Product> validProducts = new HashSet<Product>();

            foreach (var productDto in importedProductDtos)
            {
                Product validProduct = mapper.Map<Product>(productDto);

                validProducts.Add(validProduct);
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }

        // Problem 3
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();

            string xmlRootName = "Categories";

            XmlHelper xmlHelper = new();
            ImportCategoryDto[] categoryDtos = xmlHelper.Deserialize<ImportCategoryDto[]>(inputXml, xmlRootName);

            ICollection<Category> validCategories = new HashSet<Category>();

            foreach (var categoryDto in categoryDtos)
            {
                if (string.IsNullOrEmpty(categoryDto.Name))
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

        // Problem 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();

            string xmlRootName = "CategoryProducts";

            XmlHelper xmlHelper = new();
            ImportCategoryProductDto[] categoriProductDtos = 
                xmlHelper.Deserialize<ImportCategoryProductDto[]>(inputXml, xmlRootName);

            ICollection<CategoryProduct> validCategoryProducts = new HashSet<CategoryProduct>();

            foreach (var categoryProductDto in categoriProductDtos)
            {
                if (!context.Categories.Any(c => c.Id == categoryProductDto.CategoryId) ||
                    !context.Products.Any(p => p.Id == categoryProductDto.ProductId))
                {
                    continue;
                }

                CategoryProduct validCategoryProduct = mapper.Map<CategoryProduct>(categoryProductDto);

                validCategoryProducts.Add(validCategoryProduct);
            }

            context.CategoryProducts.AddRange(validCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoryProducts.Count}";
        }

        // Problem 5
        public static string GetProductsInRange(ProductShopContext context)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new();

            //ExportProductDto[] productDtos = context.Products
            //    .Where(p => p.Price >= 500 && p.Price <= 1000)
            //    .OrderBy(p => p.Price)
            //    .Take(10)
            //    .ProjectTo<ExportProductDto>(mapper.ConfigurationProvider)
            //    .AsNoTracking()
            //    .ToArray();

            ExportProductDto[] productDtos = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)               
                .Select(p => new ExportProductDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .AsNoTracking()
                .ToArray();

            return xmlHelper.Serializer<ExportProductDto[]>(productDtos, "Products");
        }

        public static IMapper CreateMapper()
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            cfg.AddProfile<ProductShopProfile>()));

            return mapper ;
        }
    }
}