using System;

namespace HTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string article = Console.ReadLine();

            Console.WriteLine($"<h1>");
            Console.WriteLine($"    {article}");
            Console.WriteLine("</h1>");

            string contentOfArticle = Console.ReadLine();

            Console.WriteLine($"<article>");
            Console.WriteLine($"    {contentOfArticle}");
            Console.WriteLine("</article>");

            string comment = string.Empty;

            while ((comment = Console.ReadLine()) != "end of comments")
            {
                Console.WriteLine($"<div>");
                Console.WriteLine($"    {comment}");
                Console.WriteLine("</div>");
            }
        }
    }
}
