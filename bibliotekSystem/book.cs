using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliotekSystem
{
    class book
    {
        public string Author { get; set; }

        public string Titel { get; set; }

        public string Format { get; set; }

        public bool Loaned { get; set; }

        public book(string Author, string Titel, string Format, bool Loaned)
        {
            this.Author = Author;
            this.Titel = Titel;
            this.Format = Format;
            this.Loaned = Loaned;
        }

        public static void addBook (List<book> mainList)
        {
            int quantity;
            char confirmation;
            string titel, author, format;
            bool loaned;

            Console.WriteLine("How many books do you want to add?");
            quantity = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i < quantity; i++)
            {
                Console.Write("Author: ");
                author = Console.ReadLine().ToLower();

                Console.Write("Titel: ");
                titel = Console.ReadLine().ToLower();

                Console.Write("Format(comicbook, manga or book): ");
                format = Console.ReadLine().ToLower();

                if(format == "comicbook" || format == "manga" || format == "book")
                {

                }
            }

        }
    }
}
