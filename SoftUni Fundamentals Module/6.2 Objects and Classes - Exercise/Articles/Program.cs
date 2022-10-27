using System;
using System.Linq;

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] readArticle = Console.ReadLine()
                .Split(", ")
                .ToArray();
            int numberOfCommands = int.Parse(Console.ReadLine());

            Articles article = new Articles(readArticle[0], readArticle[1], readArticle[2]);

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(": ")
                    .ToArray();

                string operation = command[0];
                string argument = command[1];

                if (operation == "Edit")
                {
                    article.EditNewContent(argument);            
                }
                else if (operation == "ChangeAuthor")
                {
                    article.ChangeAuthor(argument);
                }
                else if (operation == "Rename")
                {
                    article.RenameTitle(argument);
                }             
            }

            Console.WriteLine(article);
        }
    }

    class Articles
    {
        public Articles(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }


        public void EditNewContent(string content) => Content = content;

        public void ChangeAuthor(string author) => Author = author;

        public void RenameTitle(string title) => Title = title;

        public override string ToString() => $"{Title} - {Content}: {Author}";

    }
}
