using AutoMapper;
using ProductShop.Data;
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
            //string inputXml = File.ReadAllText(@"../../../D*/atasets/users.xml");
            //string result = ImportUsers(context, inputXml);

            // Problem 2
            string inputXml = File.ReadAllText(@"../../../Datasets/products.xml");
            string result = ImportProducts(context, inputXml);

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

        public static IMapper CreateMapper()
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            cfg.AddProfile<ProductShopProfile>()));

            return mapper ;
        }
    }
}