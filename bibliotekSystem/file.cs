using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliotekSystem
{
    class file
    {
        // Function that reads book data in to a textfile
        public static void bookDataOut (List<book> books)
        {
            // Opens file
            StreamWriter writeFile = new StreamWriter("books.txt");

            // A loop that goes through the whole list and reads the data in to the textfile
            for (int i = 0; i < books.Count; i++)
            {
                writeFile.WriteLine(books[i].Author + "|" + books[i].Titel + "|" + books[i].Format + "|" + books[i].Loaned + "|" + books[i].Id);

                // Removes previous data in textfile
                writeFile.Flush();
            }

            // Closes file
            writeFile.Close();
        }

        // Function that reads data from textfile and that adds data to list
        public static void bookDataIn (List<book> books)
        {
            string author, titel, format;
            bool loaned;
            books.Clear(); 

            // Opens file
            StreamReader writeFile = new StreamReader("books.txt");
            string s;

            // A loop that goes through the textfile until it's empty
            while ((s = writeFile.ReadLine()) != null)
            {
                // splitting lines at every |
                string[] bookData = s.Split('|');

                // Takes data from list
                author = bookData[0];
                titel = bookData[1];
                format = bookData[2];
                loaned = Convert.ToBoolean(bookData[3]);

                // Takes data and adds a new book
                books.Add(new book(author, titel, format, loaned));
            }

            // giving every book an ID
            for(int i = 0; i < books.Count; i++)
            {
                books[i].Id = i;
            }

            // Closes file
            writeFile.Close();
        }

    }
}
