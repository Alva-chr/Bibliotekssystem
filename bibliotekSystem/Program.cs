using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliotekSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<book> mainBookList = new List<book>();
            List<book> temporaryList = new List<book>();

            int answer, searchMenuAnswer = 0;

            string searchWord = " ";

            Console.WriteLine("Welcome to my library system!");

            do
            {
                //reads in data from textfile
                file.bookDataIn(mainBookList);

                Console.Clear();

                //mainmenu
                Console.WriteLine("What to you want to do?");
                Console.WriteLine("1. Search");
                Console.WriteLine("2. Add books");
                Console.WriteLine("3. Show all books");
                Console.WriteLine("4. Exit");

                answer = Convert.ToInt32(Console.ReadLine());

                switch (answer)
                {
                    case 1:

                        book.searchInput(searchWord, mainBookList, temporaryList);

                        Console.WriteLine("What do you want to do?");
                        Console.WriteLine("1. Delete books");
                        Console.WriteLine("2. Loan book");
                        Console.WriteLine("3. Return book");
                        Console.WriteLine("4. Exit");

                        searchMenuAnswer = Convert.ToInt32(Console.ReadLine());

                        switch (searchMenuAnswer)
                        {
                            case 1:
                                // delete one or more books funtion
                                book.deleteBook(searchWord, mainBookList, temporaryList);
                                break;

                            case 2:
                                // Loan book funtion
                                break;

                            case 3:
                                // return book funtion
                                break;

                            case 4:
                                Console.WriteLine("You will noe be redirected back to the main menu!");
                                break;

                            default:
                                Console.WriteLine("Invalid input, you will now be redirected back to the Main Menu!");
                                Console.ReadKey();
                                break;
                        }

                        break;

                    case 2:
                        book.addBook(mainBookList);
                        break;

                    case 3:
                        book.showAllBooks(mainBookList);
                        break;

                    case 4:

                        break;
                }
            }
            while (answer != 4);

        }
    }
}
