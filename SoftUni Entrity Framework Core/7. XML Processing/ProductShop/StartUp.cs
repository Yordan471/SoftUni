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

            string inputXml = File.ReadAllText(@"../../../Datasets/users.xml");
            string result = ImportUsers(context, inputXml);
            Console.WriteLine(result);
        }

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

        public static IMapper CreateMapper()
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            cfg.AddProfile<ProductShopProfile>()));

            return mapper ;
        }
    }
}