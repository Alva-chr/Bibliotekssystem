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

        public static void searchInput(string searchWord, List<book> books, List<book> foundlings)
        { 
            char tryAgain;

            foundlings.Clear();

            while(foundlings.Count == 0)
            {
                //input from user regarding search
                Console.Write("Enter search word (either titel or author): ");
                searchWord = Console.ReadLine().ToLower();

                //calls the search function
                search(searchWord, books, foundlings);

                //if it doesn't find a match
                if (foundlings.Count == 0)
                {
                     Console.WriteLine("We couldn't find anything matching what you searched for." +
                            "Do you want to try again (Y/N)?");

                     tryAgain = Convert.ToChar(Console.ReadLine().ToLower());

                    //if user wants return to mainmenu
                     if (tryAgain == 'n')
                     {
                        return;
                     }

                     //let's user try again
                     else if (tryAgain == 'y')
                     {
                        Console.WriteLine("You will now get to try again!");
                     }

                     //if user don't know how to read and don't know how to write Y/N
                     else
                     {
                        Console.WriteLine("Invalid input, you will now get to try again!");
                     }
                }

                //write out all the books found
                else if (foundlings.Count > 0)
                {
                    Console.WriteLine("We found these books:");

                    showAllBooks(foundlings);
                }
            }
        }

        //options what to do with the foundlings
        public static void searchMenu()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Delete books");
            Console.WriteLine("2. Loan book");
            Console.WriteLine("3. Return book");
            Console.WriteLine("4. Exit");
        }

        public static void deleteBook(string searchWord, List<book> mainList, List<book> foundlings)
        {
            int option, id;

            search(searchWord, mainList, foundlings);

            //Menu when the users books have been found
            Console.WriteLine("choose on of the following options");
            Console.WriteLine("1. Delete all the books shown");
            Console.WriteLine("2. Delete one book ");
            Console.WriteLine("3. Exit");
            Console.Write("Option: ");

            option = Convert.ToInt32(Console.ReadLine());

            //deletes all the books found in search
            if (option == 1)
            {
                Console.WriteLine("All the following books will now be deleted: ");
                showAllBooks(foundlings);

                //lopp that goes through the foundlings list
                for(int i = 0; i < foundlings.Count; i++)
                {
                    //loop that goes through the mainlist
                    for( int j = 0; j < mainList.Count; j++)
                    {
                        //compares the foundlingslist with the mainlst an removes froms the mainlist if it matches
                        if(mainList[j].Titel == foundlings[i].Titel || mainList[j].Author == foundlings[i].Author)
                        {
                            mainList.RemoveAt(j);
                        }
                    }
                }

                //updates data in file
                file.bookDataOut(mainList);
            }

            //deletes one book by ID
            else if (option == 2)
            {
                //user input for ID
                Console.Write("Enter the id of the book you want to delete: ");
                id = Convert.ToInt32(Console.ReadLine());

                //goes through mainlist 
                for(int i = 0; i < mainList.Count; i++)
                {
                    //removes match
                    if(mainList[i].Id == id)
                    {
                        Console.WriteLine("The book with the id " + mainList[i].Id + " has now been removed.");
                        mainList.RemoveAt(id);
                    }
                }  
            }

            //goes back to main menu
            else if(option == 3)
            {
                return;
            }

            // goes back to main menu
            else
            {
                Console.WriteLine("Invalid input, you will be redirected to the main menu!");
                return;
            }

            file.bookDataOut(mainList);
        }

        //Loaning book funtion
        public static void loanBook (int id, List<book> mainList)
        {
            Console.Write("enter ID: ");
            id = Convert.ToInt32(Console.ReadLine());

            //goes through mainlist and find match
            for(int i = 0; i < mainList.Count; i++)
            {
                if(mainList[i].Id == id)
                {
                    //user can't loan book if it is already loaned
                    if (mainList[i].Loaned == true)
                    {
                        Console.WriteLine("You can't loan this book! It's already loaned by someone. You will now be returned to the mainmenu");
                    }

                    //changes status to loaned if it isn't loaned
                    if(mainList[i].Loaned == false)
                    {
                        mainList[i].Loaned = true;
                        file.bookDataOut(mainList);

                        Console.WriteLine("The book is now yours to take! You will now be redirected to the main menu.");
                    }
                }
            }  
        }

        //returning book function
        public static void returnBook(int id, List<book> mainList)
        {
            Console.Write("enter ID: ");
            id = Convert.ToInt32(Console.ReadLine());

            //checks mainlist for match
            for (int i = 0; i < mainList.Count; i++)
            {
                if (mainList[i].Id == id)
                {
                    //retunrs book if it's loaned
                    if (mainList[i].Loaned == true)
                    {
                        mainList[i].Loaned = false;
                        Console.WriteLine("The book is now retuned! You will noe be redirected to the mainmenu!");
                        file.bookDataOut(mainList);
                    }

                    //error message if user tries to retunr book that isn't load
                    if (mainList[i].Loaned == false)
                    {
                        Console.WriteLine("This book is not loaned! You can't return it! You will now be redirected back to the main menu!");
                    }
                }
            }
        }
    }
}
