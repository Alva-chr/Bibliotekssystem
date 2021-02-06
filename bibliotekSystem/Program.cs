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
            int val = 1, antal, sokVal, id;
            string sokOrd = "aka akasaka";


            List<hanteraBok> bokLista = new List<hanteraBok>();
            List<hanteraBok> tempLista = new List<hanteraBok>();

            while (val != 4)
            {
                filHantering.inData(bokLista);
                tempLista.Clear();

                Console.Clear();

                Console.WriteLine("Vad vill du göra? ");
                Console.WriteLine("1. Sök");
                Console.WriteLine("2. Lägga till bok");
                Console.WriteLine("3. Lista alla Böcker");
                Console.WriteLine("4. Avsluta");

                val = Convert.ToInt32(Console.ReadLine());

                switch (val)
                {
                    case 1:
                        Console.Clear();
                        char beslut;

                        while(tempLista.Count == 0)
                        {
                            tempLista.Clear();
                            sokOrd = null;
                            Console.WriteLine("Vad för bok vill du söka efter (författer eller Titel)");
                            sokOrd = Console.ReadLine().ToLower();

                            
                            filHantering.sokFunktion(bokLista, tempLista, sokOrd);

                            if(tempLista.Count == 0)
                            {


                                Console.WriteLine("Vill du testa igen (Y/N)? ");
                                beslut = Convert.ToChar(Console.ReadLine().ToLower());

                                if (beslut == 'n')
                                {
                                    break;
                                }

                                else if (beslut == 'y')
                                {
                                    Console.WriteLine("Tryck enter för att testa igen!");
                                    Console.ReadKey();
                                }

                                else
                                {
                                    Console.WriteLine("Du angav ett felaktigt värde, du kommer få testa igen.");
                                }

                            }

                        }

                        if (tempLista.Count >= 1)
                        {
                            Console.WriteLine("Vad vill du göra? ");
                            Console.WriteLine("1. Ta bort bok");
                            Console.WriteLine("2. Låna bok");
                            Console.WriteLine("3. återlämna bok");

                            sokVal = Convert.ToInt32(Console.ReadLine());

                            switch (sokVal)
                            {
                                case 1:
                                    filHantering.taBortBok(bokLista, sokOrd);
                                    break;

                                case 2:
                                    hanteraBok.lanaBokID(bokLista);

                                    break;

                                case 3:
                                    hanteraBok.aterlamnaBok(bokLista);

                                    break;

                                default:
                                    Console.WriteLine("Du har angett ett olgiltigt svar;");
                                    break;

                            }
                            break;

                        }

                        break;

                    case 2:

                        Console.Write("Hur många böcker vill du lägga till? ");
                        antal = Convert.ToInt32(Console.ReadLine());

                        hanteraBok.laggaBok(antal, bokLista);

                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Dessa böcker finns lagrade just nu!!");
                        hanteraBok.listaBocker(bokLista);
                        Console.ReadKey();

                        break;

                    case 4:

                        break;

                    default:
                        break;

                }

            }


            Console.ReadKey();
        }
    }
}
