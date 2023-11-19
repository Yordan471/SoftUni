using AutoMapper;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {

        }



        public static IMapper Mapper()
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            cfg.AddProfile<CarDealerProfile>()));

            return mapper;
        }
    }
}