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

        public int Id;

        // Constructor for a book
        public book(string Author, string Titel, string Format, bool Loaned)
        {
            this.Author = Author;
            this.Titel = Titel;
            this.Format = Format;
            this.Loaned = Loaned;
        }

        // function to list all books in a list
        public static void showAllBooks (List<book> books)
        {
            // A loop that goes through the list and write out data about the book
            for(int i = 0; i < books.Count; i++)
            {
                Console.WriteLine("Author: " + books[i].Author + " | Titel: " + books[i].Titel + " | Format: " + books[i].Format + " | Loaned: " + books[i].Loaned + " | ID: " + books[i].Id);
            }
            Console.ReadKey();
        }

        // Function to add books
        public static void addBook (List<book> mainList)
        {
            List<book> tempList = new List<book>();
            int quantity;
            char confirmation;
            string titel, author, format = "book";


            // Input regarding how many books the user want to add
            Console.WriteLine("How many books do you want to add?");
            quantity = Convert.ToInt32(Console.ReadLine());

            // a loop that repeats for every book the user want to add
            for(int i = 0; i < quantity; i++)
            {
                bool formatSuccess = false;

                Console.Write("Author: ");
                author = Console.ReadLine().ToLower();

                Console.Write("Titel: ");
                titel = Console.ReadLine().ToLower();

                // checks if the users input is one of the approved formats
                while (formatSuccess == false)
                {
                    Console.Write("Format(comicbook, manga or book): ");
                    format = Console.ReadLine().ToLower();

                    if (format == "comicbook" || format == "manga" || format == "book")
                    {
                        formatSuccess = true;
                    }

                    else
                    {
                        Console.WriteLine("You have entered an invalid option, please try again!");
                    }
                }

                // Adds new book to temporary list
                tempList.Add(new book(author, titel, format, false));
            }

            showAllBooks(tempList);

            //Confirms that the user want to add all the books in tempList
            Console.Write("Do you want to add these books (Y/N)? ");
            confirmation = Convert.ToChar(Console.ReadLine().ToLower());

            if (confirmation == 'y')
            {
                // A loop that gives the new books an ID depending on what place they have in the mainlist and adds them to the main list
                for (int i = 0; i < tempList.Count; i++)
                {
                    tempList[i].Id = mainList.Count;
                    mainList.Add(tempList[i]);

                    // Saves data in textfile
                    file.bookDataOut(mainList);
                }

                Console.WriteLine("All the books have now been added!");
                return;
            }

            else if (confirmation == 'n')
            {
                Console.WriteLine("None of these books will be added. Press enter to return to the start menu!");
                Console.ReadKey();
            }

            else
            {
                Console.WriteLine("Your input was not one of the above choices. None of these books will be added and you will be directed back to the start menu");
                Console.ReadKey();
            }
        }

        //search function that will search for author and titel
        public static void search (string searchWord, List<book> books, List<book> foundlings)
        {
            // loop that goes through the mainlist
            for(int i = 0; i < books.Count; i++)
            {
                //if it fins a match it will add the object to the foundlings list
                if(searchWord == books[i].Author || searchWord == books[i].Titel)
                {
                    foundlings.Add(books[i]);
                }
            }
        }

        public static void searchInput(List<book> books, List<book> foundlings)
        {
            string searchWord;
            char tryAgain = 'y';

            foundlings.Clear();

            while(foundlings.Count == 0)
            {
                Console.Write("Enter search word (either titel or author): ");
                searchWord = Console.ReadLine().ToLower();

                search(searchWord, books, foundlings);

                if (foundlings.Count == 0)
                {
                     Console.WriteLine("We couldn't find anything matching what you searched for." +
                            "Do you want to try again (Y/N)?");

                     tryAgain = Convert.ToChar(Console.ReadLine().ToLower());

                     if (tryAgain == 'n')
                     {
                         break;
                     }

                     else if (tryAgain == 'y')
                     {
                        Console.WriteLine("You will now get to try again!");
                     }

                     else
                    {
                        Console.WriteLine("Invalid input, you will now get to try again!");
                    }
                }

                else if (foundlings.Count > 0)
                {
                    Console.WriteLine("We found these books:");

                    showAllBooks(foundlings);
                }
            }
        }

        public static void searchMeny()
        {
            int answer;

            Console.WriteLine("What do you want to do?");
            answer = Convert.ToInt32(Console.ReadLine());

            switch (answer)
            {
                case 1:
                    break;

                case 2:
                    break;

                case 3:
                    break;
            }
        }
    }
}
