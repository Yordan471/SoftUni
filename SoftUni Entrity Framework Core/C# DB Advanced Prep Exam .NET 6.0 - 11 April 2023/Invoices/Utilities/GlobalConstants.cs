using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Invoices.Utilities
{
    public class GlobalConstants
    {
        // Products
        public const int ProductNameLengthConstraintMin = 9;
        public const int ProductNameLengthConstraintMax = 30;
        public const decimal ProductPriceRangeMin = 5.0M;
        public const decimal ProductPriceRangeMax = 1000.00M;

        // Addresses
        public const int AddressesStreetNameLengthMin = 10;
        public const int AddressesStreetNameLengthMax = 20;
        public const int AddressesCityNameLengthMin = 5;
        public const int AddressesCityNameLengthMax = 15;
        public const int AddressesCountryNameLengthMin = 5;
        public const int AddressesCountryNameLengthMax = 5;

        // Invoices
        public const int InvoicesNumberRangeMin = 1000000000;
        public const int InvoicesNumberRangeMax = 1500000000;

        // Client
        public const int ClientFullNameLengthMin = 10;
        public const int ClientFullNameLengthMax = 25;
        public const int ClientVatNumberLengthMin = 10;
        public const int ClientVatNumberLengthMax = 25;
    }
}
