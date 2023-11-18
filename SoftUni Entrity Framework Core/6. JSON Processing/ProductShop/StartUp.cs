using AutoMapper;
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

            string inputJson = File.ReadAllText(@"../../../Datasets/users.json");

            string result = ImportUsers(context, inputJson);

            Console.WriteLine(result);  
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


        }     
    }
}