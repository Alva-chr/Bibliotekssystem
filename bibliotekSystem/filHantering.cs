﻿using System;
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

                list.Add(new hanteraBok(tit, forF, form, lan));
                
       
            }

            lasFil.Close();
            
        }

        public static void utData(List<hanteraBok> lista)
        {
            StreamWriter skrivfil = new StreamWriter("bocker.txt");

            

            for(int i = 0; i < lista.Count; i++)
            {
                skrivfil.Write("");
                skrivfil.WriteLine(lista[i].Titel + "|" + lista[i].Forfattare + "|" + lista[i].Format + "|" + lista[i].Lanad);
            }

            skrivfil.Close();
        }




    }
}