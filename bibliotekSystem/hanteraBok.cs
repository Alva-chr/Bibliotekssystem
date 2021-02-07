using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliotekSystem
{
    public class hanteraBok
    {
        public int Id;
        public string Titel { get; set; }

        public string Forfattare { get; set; }

        public string Format { get; set; }

        public bool Lanad { get; set; }

        //konstruktor för bok
        public hanteraBok(string Title, string ffa, string fma, bool l)
        {
            this.Titel = Title;
            this.Forfattare = ffa;
            this.Format = fma;
            this.Lanad = l;
        }

        public static void lanaBokID()
        {
            int id;

            Console.Write("Vad för id har boken du vill låna? ");

            id = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < Program.bokLista.Count(); i++)
            {
                if(Program.bokLista[i].Id == id)
                {
                    if (Program.bokLista[i].Lanad == true)
                    {
                        Console.WriteLine("Boken redan lånad och därav kan du inte låna den ");
                        Console.ReadKey();
                        return;
                    }

                    else if (Program.bokLista[i].Lanad == false)
                    {
                        Program.bokLista[i].Lanad = true;
                        Console.WriteLine("Bok är nu lånad!");
                        
                        
                        break;
                    }
                }
            }
        }

        public static void aterlamnaBok()
        {
            int id;

            Console.Write("Vad för id har boken du vill återlämna? ");

            id = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < Program.bokLista.Count(); i++)
            {
                if (Program.bokLista[i].Id == id)
                {
                    if (Program.bokLista[i].Lanad == true)
                    {
                        Console.WriteLine("Boken är återlämnad!");
                        Program.bokLista[i].Lanad = false;
                        break;
                    }

                    else if (Program.bokLista[i].Lanad == false)
                    {
                        Console.WriteLine("Denna bok är inte lånad och därav kan du inte återlämna den! ");
                        Console.ReadKey();
                    }
                }
            }

        }

        public static void listaBocker(List<hanteraBok> lista)
        {
            for (int i = 0; i< lista.Count; i++)
            {
                Console.WriteLine("Titel: " + lista[i].Titel + " | Författare: " + lista[i].Forfattare + " | Format: " + lista[i].Format +" | Lånad: "+ lista[i].Lanad + " | ID: " + lista[i].Id);
            }
        }

        public static void laggaBok(int antal)
        {
            string titel, forfattare, format = "";
            char beslut;
            List<hanteraBok> nyBok = new List<hanteraBok>();



            Console.WriteLine("Nu kommer du få lägga till böcker");

            for (int i = 0; i < antal; i++)
            {
                bool formatForsok = false;

                Console.Write("Titel: ");
                titel = Console.ReadLine().ToLower();

                Console.Write("Författare: ");
                forfattare = Console.ReadLine().ToLower();

                while (formatForsok == false)
                {
                    Console.Write("Format(Serietiding, Manga eller Bok): ");
                    format = Console.ReadLine().ToLower();

                    if (format == "manga" || format == "bok" || format == "serietidning")
                    {
                        formatForsok = true;
                    }

                    else
                    {
                        Console.WriteLine("Detta är inte ett tillåtet format, Vänligen försök ange ett korrekt format igen");
                    }
                }

                nyBok.Add(new hanteraBok(titel, forfattare, format, false));
            }

            Console.Clear();

            hanteraBok.listaBocker(nyBok);

            Console.Write("Vill du lägga till alla böcker över(Y/N)? ");
            beslut = Convert.ToChar(Console.ReadLine().ToLower());

            if (beslut == 'y')
            {
                for (int i = 0; i < nyBok.Count; i++)
                {
                    nyBok[i].Id = Program.bokLista.Count;
                    Program.bokLista.Add(nyBok[i]);
                }
                filHantering.utData(Program.bokLista);
            }

            else if (beslut == 'n')
            {
                Console.WriteLine("Inga böcker komma läggas till");
                nyBok.Clear();
            }

            else 
            {
                Console.WriteLine("Du angav ett felaktigt värde, inga böcker kommer läggas till");
                nyBok.Clear();
            }
        }
    }
}
