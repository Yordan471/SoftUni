using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolLibary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> shelfWithBooks = Console.ReadLine()
                .Split('&')
                .ToList();

            string command = Console.ReadLine();

            while (true)
            {
                if (command == "Done")
                {
                    break;
                }

                string[] commandToArray = command
                .Split(" | ")
                .ToArray();

                string operation = commandToArray[0];

                switch (operation)
                {
                    case "Add Book":
                        string bookName = commandToArray[1];
                        AddBook(shelfWithBooks, bookName);
                        break;
                    case "Take Book":
                        bookName = commandToArray[1];
                        TakeBook(shelfWithBooks, bookName);
                        break;
                    case "Swap Books":
                        string book1 = commandToArray[1];
                        string book2 = commandToArray[2];
                        SwapBooks(shelfWithBooks, book1, book2);
                        break;
                    case "Insert Book":
                        bookName = commandToArray[1];
                        InsertBook(shelfWithBooks, bookName);
                        break;
                    case "Check Book":
                        int index = int.Parse(commandToArray[1]);
                        CheckBook(shelfWithBooks, index);
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(", ", shelfWithBooks));
        }

        static List<string> AddBook(List<string> shelfWithBooks, string bookName)
        {
            if (shelfWithBooks.Contains(bookName) == false)
            {
                shelfWithBooks.Insert(0, bookName);
            }

            return shelfWithBooks;
        }

        static List<string> TakeBook(List<string> shelfWithBooks, string bookName)
        {
            if (shelfWithBooks.Contains(bookName))
            {
                shelfWithBooks.Remove(bookName);
            }

            return shelfWithBooks;
        }

        static List<string> SwapBooks(List<string> shelfWithBooks, string book1, string book2)
        {
            if (shelfWithBooks.Contains(book1) &&
                shelfWithBooks.Contains(book2))
            {
                int book1Index = shelfWithBooks.IndexOf(book1);
                int book2Index = shelfWithBooks.IndexOf(book2);

                string bookOneName = shelfWithBooks[book1Index];
                string bookTwoName = shelfWithBooks[book2Index];

                shelfWithBooks.Insert(book1Index, bookTwoName);
                shelfWithBooks.RemoveAt(book2Index + 1);
                shelfWithBooks.Insert(book2Index + 1, bookOneName);
                shelfWithBooks.RemoveAt(book1Index + 1);
            }

            return shelfWithBooks;
        }

        static List<string> InsertBook(List<string> shelfWithBooks, string bookName)
        {
            if (shelfWithBooks.Contains(bookName) == false)
            {
                shelfWithBooks.Add(bookName);
            }

            return shelfWithBooks;
        }

        static void CheckBook(List<string> shelfWithBooks, int index)
        {
            if (index >= 0 && index < shelfWithBooks.Count)
            {
                if (shelfWithBooks.Contains(shelfWithBooks[index]))
                {
                    Console.WriteLine($"{shelfWithBooks[index]}");
                }
            }
        }
    }
}
