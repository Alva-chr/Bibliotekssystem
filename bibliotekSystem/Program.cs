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

            int answer, searchMenuAnswer, id = 0;

            string searchWord = " ";

            bool succes = false;

            Console.WriteLine("Welcome to my library system!");

            do
            {
                //reads in data from textfile
                file.bookDataIn(mainBookList);
                temporaryList.Clear();

                Console.Clear();

                //mainmenu
                Console.WriteLine("What to you want to do (enter a number)?");
                Console.WriteLine("1. Search");
                Console.WriteLine("2. Add books");
                Console.WriteLine("3. Show all books");
                Console.WriteLine("4. Exit");

                succes = Int32.TryParse(Console.ReadLine(), out answer);

                if (succes == true)
                {
                    switch (answer)
                    {
                        case 1:
                            //let's user search for book with titel or authors name
                            book.searchInput(searchWord, mainBookList, temporaryList);

                            if (temporaryList.Count >= 1)
                            {
                                //displayss searchmenu
                                book.searchMenu();

                                searchMenuAnswer = Convert.ToInt32(Console.ReadLine());

                                switch (searchMenuAnswer)
                                {
                                    case 1:
                                        // delete one or more books funtion
                                        book.deleteBook(searchWord, mainBookList, temporaryList);

                                        break;

                                    case 2:
                                        // loan one book
                                        book.loanBook(id, temporaryList);

                                        break;

                                    case 3:
                                        // return book funtion
                                        book.returnBook(id, mainBookList);

                                        break;

                                    case 4:
                                        Console.WriteLine("You will noe be redirected back to the main menu!");
                                        break;

                                    default:
                                        Console.WriteLine("Invalid input, you will now be redirected back to the Main Menu!");
                                        Console.ReadKey();
                                        break;
                                }

                            }

                            break;

                        case 2:
                            book.addBook(mainBookList);
                            break;

                        case 3:
                            book.sortingBook(mainBookList);
                            Console.ReadKey();
                            break;

                        case 4:

                            break;
                    }
                }

                else
                {
                    Console.WriteLine("Please try again, It said to enter a number! Please press enter to try again!");
                    Console.ReadKey();
                }
               
            }
            while (answer != 4);
        }
    }
}
