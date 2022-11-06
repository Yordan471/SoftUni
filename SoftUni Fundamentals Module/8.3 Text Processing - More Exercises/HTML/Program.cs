using System;
using System.Collections.Generic;

namespace HTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string article = Console.ReadLine();

            List<string> list = new List<string>();

            list.Add($"<h1>");
            list.Add($"    {article}");
            list.Add("</h1>");

            string contentOfArticle = Console.ReadLine();

            list.Add($"<article>");
            list.Add($"    {contentOfArticle}");
            list.Add("</article>");

            string comment = string.Empty;

            while ((comment = Console.ReadLine()) != "end of comments")
            {
                list.Add($"<div>");
                list.Add($"    {comment}");
                list.Add("</div>");
            }

            Console.WriteLine(string.Join(Environment.NewLine, list));
        }
    }
}
