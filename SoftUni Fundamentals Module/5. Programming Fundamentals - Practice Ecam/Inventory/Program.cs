using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> collectingItems = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();
            

            while (true)
            {
                if (command == "Craft!")
                {
                    break;
                }

                List<string> operations = command
                    .Split()
                    .ToList();

                string operation = operations[0];
                string item = operations[2];

                if (operation == "Collect")
                {
                    CollectItem(collectingItems, item);
                }
                else if (operation == "Drop")
                {
                    DropItem(collectingItems, item);
                }
                else if (operation == "Renew")
                {
                    RenewItem(collectingItems, item);
                }
                else
                {
                    List<string> items = operations[3]
                        .Split(':')
                        .ToList();

                    string oldItem = items[0];
                    string newItem = items[1];
                    
                    CombineItems(collectingItems, oldItem, newItem);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(", ", collectingItems));
        }

        static List<string> CollectItem(List<string> collectingItems, string item)
        {

            if (collectingItems.Contains(item) == false)
            {
                collectingItems.Add(item);
            }

            return collectingItems;
        }

        static List<string> DropItem(List<string> collectingItems, string item)
        {
            if (collectingItems.Contains(item))
            {
                collectingItems.Remove(item);
            }

            return collectingItems;
        }

        static List<string> RenewItem(List<string> collectingItems, string item)
        {
            if (collectingItems.Contains(item))
            {
                collectingItems.Remove(item);
                collectingItems.Add(item);
            }

            return collectingItems;
        }

        static List<string> CombineItems(List<string> collectingItems, string oldItem, string newItem)
        {
            if (collectingItems.Contains(oldItem))
            {
                for (int i = 0; i < collectingItems.Count; i++)
                {
                    if(collectingItems[i] == oldItem)
                    {
                        collectingItems.Insert(i + 1, newItem);
                    }
                }
            }

            return collectingItems;
        }
    }
}
