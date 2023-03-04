using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Calling(string phoneNumber)
        {
            if (!ValidatePhoneNumber(phoneNumber))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {phoneNumber}";
        }

        public string Browsing(string url)
        {
            if (!ValidateWebAdress(url))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {url}!";
        }

        public bool ValidatePhoneNumber(string phoneNumber)
        {
            if (!int.TryParse(phoneNumber, out int number))
            {
                return false;
            }

            //if (phoneNumber.All(c => char.IsDigit(c)))
            //{
            //    return true;
            //}
            //
            // return false;

            return true;
        }

        public bool ValidateWebAdress(string url)
        {
            foreach (char ch in url)
            {
                if (char.IsDigit(ch))
                {
                    return false;
                }
            }

          // if (url.All(c => char.IsDigit(c)))
          // {
          //     return false;
          // }

            return true;           
        }       
    }
}
