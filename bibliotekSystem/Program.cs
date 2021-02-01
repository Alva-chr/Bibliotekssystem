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
            int val = 1, antal, sokVal;
            string sokOrd;
            char svar = ' ';

            List<hanteraBok> bokLista = new List<hanteraBok>();
            List<hanteraBok> tempLista = new List<hanteraBok>();

            while (val != 5)
            {
                filHantering.inData(bokLista);

                Console.Clear();

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
                        Console.Clear();
                        Console.WriteLine("Vad för bok vill du söka efter (författer eller Titel)");
                        sokOrd = Console.ReadLine().ToLower();

                        tempLista.Clear();
                        filHantering.sokFunktion(bokLista, tempLista,sokOrd);

                        if (svar == 'n')
                        {
                            return;
                        }

                        Console.WriteLine("Vad vill du göra? ");
                        Console.WriteLine("1. Ta bort bok");
                        Console.WriteLine("2. Låna bok");

                        sokVal = Convert.ToInt32(Console.ReadLine());

                        switch (sokVal)
                        {
                            case 1:
                                filHantering.taBortBok(bokLista, sokOrd);
                                break;

                            case 2:
                                break;

                            default:
                                Console.WriteLine("Du har angett ett olgiltigt svar;");
                                break;

                        }
                        break;

                    case 2:

                        Console.Write("Hur många böcker vill du lägga till? ");
                        antal = Convert.ToInt32(Console.ReadLine());

                        hanteraBok.laggaBok(antal, bokLista);

                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Dessa böcker finns lagrade just nu!!");
                        hanteraBok.listaBocker(bokLista);

                        break;

                    default:
                        break;

                }

            }


            Console.ReadKey();
        }
    }
}
