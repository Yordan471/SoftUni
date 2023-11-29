using System.ComponentModel.DataAnnotations;

namespace Trucks.Utilities
{
    public class GlobalConstants
    {
        // Truck
        public const int TruckRegistrationNumberLength = 8;
        public const string TruckRegistrationNumberRegexValidation = @"[A-Z]{2}\d{4}[A-Z]{2}";                                                                    
        public const int TruckVitNumberLength = 17;
        public const int TruckTankCapacityMin = 950;
        public const int TruckTankCapacityMax = 1420;
        public const int TruckCargoCapacityMin = 5000;
        public const int TruckCargoCapacityMax = 29000;

        // Client
        public const int ClientNameLengthMin = 3;
        public const int ClientNameLengthMax = 40;
        public const int ClientNationalityLengthMin = 2;
        public const int ClientNationalityLengthMax = 40;

        // Despatcher
        public const int DespatcherNameLengthMin = 2;
        public const int DespatcherNameLengthMax = 40;
    }
}
