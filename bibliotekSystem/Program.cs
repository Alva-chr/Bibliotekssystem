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
            int val, antal;

            List<hanteraBok> bokLista = new List<hanteraBok>();

            filHantering.inData(bokLista);

            Console.WriteLine("Vad vill du göra? ");

            Console.WriteLine("1. Sök");
            Console.WriteLine("2. Lägga till bok");
            Console.WriteLine("3. Återlämna bok");
            Console.WriteLine("4. Lista alla Böcker");
            Console.WriteLine("5. Avsluta");

            val = Convert.ToInt32(Console.ReadLine());

            switch (val)
            {
                case 1:
                    //Sökfunktion plats
                    break;

                case 2:

                    Console.Write("Hur många böcker vill du lägga till? ");
                    antal = Convert.ToInt32(Console.ReadLine());

                    hanteraBok.laggaBok(antal, bokLista);

                    break;
                default:
                    break;

            }
        }
    }
}
