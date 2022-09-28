using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
          //  bool valid = true;

            if (CheckCharachters(password) == true &&
                CheckLettersAndDigits(password) == true &&
                CheckForTwoDigits(password) == true)
            {
                Console.WriteLine("Password is valid");
            }
    
            if (CheckCharachters(password) == false)
            {
                Console.WriteLine("Password must be between 6 and 10");
            }

            if (CheckLettersAndDigits(password) == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (CheckForTwoDigits(password) == false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
        }


        static bool CheckCharachters(string password)
        {
            char[] array = password.ToCharArray();
            int counter = 0;
            bool valid = false;

            for (int i = 0; i < array.Length; i++)
            {
                counter++;
            }

            if (counter >= 6 && counter <= 10)
            {
                return valid = true;
            }
            else
            {
                return valid = false;                 
            }
        }


        static bool CheckLettersAndDigits(string password)
        {
            char[] array = password.ToCharArray();
            bool valid = false;

            for (int i = 0; i < array.Length; i++)
            {
                if ((array[i] >= '0' && array[i] <= '9') || (array[i] >= 'A' && array[i] <= 'Z') ||
                    (array[i] >= 'a' && array[i] <= 'z'))
                {
                    valid = true;
                }
                else
                {                   
                    valid = false;
                    break;
                }            
            }

            return valid;
        }

        static bool CheckForTwoDigits(string password)
        {
            char[] array = password.ToCharArray();
            int counterForTwoDigits = 0;
            bool valid = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= '0' && array[i] <= '9')
                {
                    counterForTwoDigits++;
                }
            }

            if (counterForTwoDigits >= 2)
            {
                return valid = true;
            }
            else
            {              
                return valid = false;
            }
        }
    }
}
