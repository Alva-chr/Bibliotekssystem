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

        public void lanaBok(List<hanteraBok> lista)
        {
                if (lista[0].Lanad == true)
                {
                    lista[0].Lanad = false;
                }

                else
                {
                    lista[0].Lanad = true;
                }
        }

        public void lanaBokID(List<hanteraBok> lista, int id)
        {
            if (lista[id].Lanad == true)
            {
                lista[id].Lanad = false;
            }

            else if (lista[id].Lanad == false)
            {
                lista[id].Lanad = true;
            }
        }

        public static void listaBocker(List<hanteraBok> lista)
        {
            for (int i = 0; i< lista.Count(); i++)
            {
                Console.WriteLine("Titel: " + lista[i].Titel + " | Författare: " + lista[i].Forfattare + " | Format: " + lista[i].Format + " | ID: " + lista[i].Id);
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
