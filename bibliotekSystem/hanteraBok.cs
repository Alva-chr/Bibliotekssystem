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

        //konstruktor för bok
        public hanteraBok(string t, string ffa, string fma, bool l)
        {
            titel = t;
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

        public void lanaBok(List<hanteraBok> lista)
        {
                if (lista[0].lanad == true)
                {
                    lista[0].lanad = false;
                }

                else
                {
                    lista[0].lanad = true;
                }
        }

        public void lanaBokID(List<hanteraBok> lista, int id)
        {
            if (lista[id].lanad == true)
            {
                lista[id].lanad = false;
            }

            else if (lista[id].lanad == false)
            {
                lista[id].lanad = true;
            }
        }

        public void listaBocker()
        {

        }

        public static void laggaBok(int antal, List<hanteraBok> lista)
        {
            string titel, forfattare, format = "manga" ;



            Console.WriteLine("Nu kommer du få lägga till böcker");

            for (int i = 0; i < antal; i++)
            {
                bool formatForsok = false;

                Console.Write("Titel: ");
                titel = Console.ReadLine();
                titel = titel.ToLower();

                Console.Write("Författare: ");
                forfattare = Console.ReadLine();
                forfattare = forfattare.ToLower();

                while (formatForsok == false)
                {
                    Console.Write("Format(Serietiding, Manga eller Bok): ");
                    format = Console.ReadLine();
                    format = format.ToLower();

                    if (format == "manga" || format == "bok" || format == "serietidning")
                    {
                        formatForsok = true;
                    }

                    else
                    {
                        Console.WriteLine("Detta är inte ett tillåtet format, Vänligen försök ange ett korrekt format igen");
                    }
                }

                lista.Add(new hanteraBok(titel, forfattare, format, false));

                filHantering.utData(lista);

            }
        }

    }
}
