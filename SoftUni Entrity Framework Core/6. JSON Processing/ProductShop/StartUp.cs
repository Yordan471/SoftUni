using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Export;
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

            // Problem 5
            //Console.WriteLine(GetProductsInRange(context));

            // Problem 6
            //Console.WriteLine(GetSoldProducts(context));

            // Problem 7
            //Console.WriteLine(GetCategoriesByProductsCount(context));

            // Problem 8
            Console.WriteLine(GetUsersWithProducts(context));

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
            //IMapper mapper = MappingMethod();

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

            // DTO + Auto Mapper
            //ExportProductDto[] productss = context.Products
            //    .Where(p => p.Price >= 500 && p.Price <= 1000)
            //    .OrderBy(p => p.Price)
            //    .AsNoTracking()
            //    .ProjectTo<ExportProductDto>(mapper.ConfigurationProvider)
            //    .ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .AsNoTracking()
                .Select(u => new 
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold.Select(p => new 
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                    .ToArray()
                })
                .ToArray();

            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoriesProducts.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoriesProducts.Count,
                    averagePrice = Math.Round((double)c.CategoriesProducts.Average(cp => cp.Product.Price), 2).ToString(),
                    totalRevenue = Math.Round((double)c.CategoriesProducts.Sum(cp => cp.Product.Price), 2).ToString()
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(u => u.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Where(u => u.Buyer != null).Count())
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Where(u => u.Buyer != null).Count(),
                        products = u.ProductsSold.Where(p => p.Buyer != null).Select(p => new
                        {
                            name = p.Name,
                            price = p.Price
                        })
                        .ToArray()
                    }
                })
                .AsNoTracking()
                .ToArray();

            var userResult = new
            {
                usersCount = users.Count(),
                users = users
            };


            return JsonConvert.SerializeObject(userResult, 
                Formatting.Indented, 
                new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}