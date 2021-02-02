using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliotekSystem
{
    public class filHantering
    {
        public static void inData(List<hanteraBok> list)
        {
            string forF, tit, form;
            int id;
            bool lan;

            list.Clear();

            StreamReader lasFil = new StreamReader("bocker.txt");
            string s;

            while ((s = lasFil.ReadLine()) != null)
            {
                string[] bokData = s.Split('|');

                tit = bokData[0];
                forF = bokData[1];
                form = bokData[2];
                lan = Convert.ToBoolean(bokData[3]);
                id = Convert.ToInt32(bokData[4]);

                list.Add(new hanteraBok(tit, forF, form, lan));
                
       
            }

            lasFil.Close();
            
        }

        public static void utData(List<hanteraBok> lista)
        {
            StreamWriter skrivfil = new StreamWriter("bocker.txt", false);

            

            for(int i = 0; i < lista.Count; i++)
            {
                skrivfil.Write("");
                skrivfil.WriteLine(lista[i].Titel + "|" + lista[i].Forfattare + "|" + lista[i].Format + "|" + lista[i].Lanad + "|" + lista[i].Id);
                skrivfil.Flush();
            }

            skrivfil.Close();
        }

        public static void taBortBok(List<hanteraBok> mainLista, string sokord)
        {
            List<hanteraBok> tempLista = new List<hanteraBok>();
            char svar = 'y';
            int id;

            Console.Clear();

            sokFunktion(mainLista, tempLista, sokord);

            Console.WriteLine("a. Ta bort alla listade böcker");
            Console.WriteLine("b. Ta bort en bok");
            svar = Convert.ToChar(Console.ReadLine().ToLower());

            if(svar == 'b' || tempLista.Count == 1)
            {
                Console.Write("Ange ID för boken som du vill ta bort: ");
                id = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < mainLista.Count; i++)
                {
                    if(mainLista[i].Id == id)
                    {
                        mainLista.RemoveAt(i);
                    }
                }
                utData(mainLista);
            }

            //FUnktion för att ta bort flera böcker
            else if (svar == 'a')
            {
                //går igenom den första boken i mainlistan och jämför den med alla templistan med böcker som ska bort
                for(int i = 0; i < tempLista.Count; i++)
                { 
                    Console.WriteLine("Checkar mainlista");
                    for (int j = 0; j < mainLista.Count; j++)
                    {
                        Console.WriteLine("Checkars Templista");
                        if(mainLista[j].Titel == tempLista[i].Titel || mainLista[j].Forfattare == tempLista[i].Forfattare)
                        {
                            Console.WriteLine("Tar bort bok");
                            mainLista.RemoveAt(j);
                        }
                    }
                }

                utData(mainLista);
            }

           
        }

        public static void sokFunktion(List<hanteraBok> lista, List<hanteraBok> templista, string sokOrd)
        {

            for (int i = 0; i < lista.Count; i++)
            {
                if(lista[i].Titel == sokOrd || lista[i].Forfattare == sokOrd)
                {
                    templista.Add(lista[i]);
                }
            }

            if (templista.Count > 0)
            {
                hanteraBok.listaBocker(templista);
            }

            else
            {
                Console.WriteLine("Boken kunde ej hittas i våra system, Vänlige försök igen!");
            }
        }




    }
}
