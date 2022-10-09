using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] shoppingList = Console.ReadLine()
                .Split('!')
                .ToArray();
            string command = Console.ReadLine();

            while (true)
            {
                if (command == "Go Shopping!")
                {
                    break;
                }

                string[] commandToProducts = command
                    .Split()
                    .ToArray();

                string operation = commandToProducts[0];
                string item = commandToProducts[1];

                if (operation == "Urgent")
                {
                    shoppingList = UrgentItem(shoppingList, item);
                }
                else if (operation == "Unnecessary")
                {
                    shoppingList = UnnecessaryItem(shoppingList, item);
                }
                else if (operation == "Correct")
                {
                    string oldItem = commandToProducts[1];
                    string newItem = commandToProducts[2];

                    shoppingList = CorrectItem(shoppingList, oldItem, newItem);
                }
                else if (operation == "Rearrange")
                {
                    shoppingList = RearrangeItem(shoppingList, item);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(", ", shoppingList));
        }

        static string[] UrgentItem(string[] shoppingList, string item)
        {
            string[] saveShoppingList = new string[shoppingList.Length + 1];
            saveShoppingList[0] = item;
            bool inTheList = false;

            for (int i = 0; i < shoppingList.Length; i++)
            {
                if (saveShoppingList[0] == shoppingList[i])
                {
                    inTheList = true;
                    break;
                }               
            }

            if (inTheList == false)
            {
                for (int i = 0; i < shoppingList.Length; i++)
                {
                    saveShoppingList[i + 1] = shoppingList[i];
                }

                shoppingList = saveShoppingList;
            }

            return shoppingList;
        }

        static string[] UnnecessaryItem(string[] shoppingList, string item)
        {          
            bool removeAnItem = false;

            for (int i = 0; i < shoppingList.Length; i++)
            {
                if (shoppingList[i] == item)
                {
                    removeAnItem = true;
                    break;
                }
            }

            string[] saveShoppingList = new string[shoppingList.Length - 1];

            if (removeAnItem)
            {
                int counter = 0;

                for (int i = 0; i < saveShoppingList.Length; i++)
                {

                    if (shoppingList[i] == item)
                    {
                        saveShoppingList[i] = shoppingList[i + 1];
                        counter++;
                    }
                    else
                    {
                        saveShoppingList[i] = shoppingList[i + counter];
                    }
                }

                shoppingList = saveShoppingList;
            }

            return shoppingList;
        }

        static string[] CorrectItem(string[] shoppingList, string oldItem, string newItem)
        {
            for (int i = 0; i < shoppingList.Length; i++)
            {
                if (shoppingList[i] == oldItem)
                {
                   shoppingList[i] = newItem;
                }
            }

            return shoppingList;
        }

        static string[] RearrangeItem(string[] shoppingList, string item)
        {
            bool removeAnItem = false;

            for (int i = 0; i < shoppingList.Length; i++)
            {
                if (shoppingList[i] == item)
                {
                    removeAnItem = true;
                    break;
                }
            }

            string[] saveShoppingList = new string[shoppingList.Length];
 
            if (removeAnItem)
            {
                int counter = 0;

                for (int i = 0; i < saveShoppingList.Length - 1; i++)
                {
                    if (shoppingList[i] == item)
                    {
                        saveShoppingList[i] = shoppingList[i + 1];
                        counter++;
                    }
                    else
                    {
                        saveShoppingList[i] = shoppingList[i + counter];
                    }
                }

                saveShoppingList[saveShoppingList.Length - 1] = item;
                shoppingList = saveShoppingList;
            }

            return shoppingList;
        }
    }
}
