using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliotekSystem
{
    public class hanteraBok
    {
        private string titel;
        private string forfattare;
        private string format;
        private bool lanad;
        public int id;

        //konstruktor för bok
        public hanteraBok(string title, string ffa, string fma, bool l)
        {
            titel = title;
            forfattare = ffa;
            format = fma;
            lanad = l;
        } 

        public string Titel
        {
            get { return titel; }
            set { titel = value; }
        }

        public string Forfattare
        {
            get { return forfattare; }
            set { forfattare = value; }
        }

        public string Format
        {
            get { return format; }
            set { format = value; }
        }

        public bool Lanad
        {
            get { return lanad; }
            set { lanad = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public static void lanaBokID(List<hanteraBok> lista)
        {
            int id;

            Console.Write("Vad för id har boken du vill låna? ");

            id = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < lista.Count(); i++)
            {
                if(lista[i].id == id)
                {
                    if (lista[i].Lanad == true)
                    {
                        Console.WriteLine("Boken redan lånad och därav kan du inte låna den ");
                        Console.ReadKey();
                        return;
                    }

                    else if (lista[i].Lanad == false)
                    {
                        lista[i].Lanad = true;
                        Console.WriteLine("Bok är nu lånad!");
                        break;
                    }
                }
            }
        }

        public static void aterlamnaBok(List<hanteraBok> lista)
        {
            int id;

            Console.Write("Vad för id har boken du vill återlämna? ");

            id = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < lista.Count(); i++)
            {
                if (lista[i].id == id)
                {
                    if (lista[i].Lanad == true)
                    {
                        Console.WriteLine("Boken är återlämnad!");
                        lista[i].Lanad = false;
                        break;
                    }

                    else if (lista[i].Lanad == false)
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

        public static void laggaBok(int antal, List<hanteraBok> mainLista)
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
                    nyBok[i].Id = mainLista.Count;
                    mainLista.Add(nyBok[i]);
                }
                filHantering.utData(mainLista);
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
