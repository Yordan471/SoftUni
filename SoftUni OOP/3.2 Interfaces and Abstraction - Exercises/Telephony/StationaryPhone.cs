using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Calling(string phoneNumber)
        {
            if (!ValidateDiableNumber(phoneNumber))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Dialing... {phoneNumber}";
        }

        public bool ValidateDiableNumber(string phoneNumber)
        {
            if (phoneNumber.All(c => char.IsDigit(c)))
            {
                return true;
            }

            return false;
        }
    }   
}
