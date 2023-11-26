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
        const int ProductNameLengthConstraintMin = 9;
        const int ProductNameLengthConstraintMax = 30;
        const decimal ProductPriceRangeMin = 5.0M;
        const decimal ProductPriceRangeMax = 1000.00M;

        // Addresses
        const int AddressesStreetNameLengthMin = 10;
        const int AddressesStreetNameLengthMax = 20;
        const int AddressesCityNameLengthMin = 5;
        const int AddressesCityNameLengthMax = 15;
        const int AddressesCountryNameLengthMin = 5;
        const int AddressesCountryNameLengthMax = 5;

        // Invoices
        const int InvoicesNumberRangeMin = 1000000000;
        const int InvoicesNumberRangeMax = 1500000000;

        // Client
        const int ClientFullNameLengthMin = 10;
        const int ClientFullNameLengthMax = 25;
        const int ClientVatNumberLengthMin = 10;
        const int ClientVatNumberLengthMax = 25;
    }
}
