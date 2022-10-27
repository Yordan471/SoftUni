using System;
using System.Collections.Generic;

namespace Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = int.Parse(Console.ReadLine());

            List<Articles> articlesInList = new List<Articles>();

            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] articles = Console.ReadLine().Split(", ");

                Articles article = new Articles(articles[0], articles[1], articles[2]);

                articlesInList.Add(article);
            }

            foreach (Articles article in articlesInList)
            {
                Console.WriteLine(article);
            }
        }
    }

    class Articles
    {

        public Articles(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get; set; }

        public string Content { get; set; } 

        public string Author { get; set; }

        public override string ToString() => $"{Title} - {Content}: {Author}";

        public List<Articles> Article { get; set; } 
    }
}
