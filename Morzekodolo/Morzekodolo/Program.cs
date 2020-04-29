using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Morzekodolo
{
    class Program
    {
        static List<Morse> MorseList;
        static void Main(string[] args)
        {
            AdatokBeolvasasa();
            Console.WriteLine("\n-----------------------\n");
            Atiras(); 
            Console.WriteLine("\n-----------------------\n");
            Dekodolo();
            Console.ReadKey();
        }  

           
            private static void Dekodolo()
            {
                Console.WriteLine("Beírt Morse Kód átírása szövegbe");
                Console.Write("Kérem adjon meg egy szöveget amit szeretne átalakítani: ");
                string Szoveg = Console.ReadLine();
                string[] word = Szoveg.Split(' ');
                int n = Szoveg.Length;
                string[] tmbDekodol = new string[n];
                string DeKodolt = "";
                foreach (var W in word)
                {
                    foreach (var m in MorseList)
                    {
                        if (W == m.MorseKod)
                        {
                            DeKodolt = DeKodolt + m.Betu + " ";
                        }
                    }
                }
                Console.WriteLine("A kódolt szöveg: {0}", DeKodolt);
            }

            private static void Atiras()
            {
                Console.WriteLine("Beírt szövek átírása Morse Kódba");
                Console.Write("Kérem adjon meg egy szöveget amit szeretne átalakítani: ");
                string Szoveg = Console.ReadLine().Replace('í', 'i').Replace('ó', 'o').Replace('ő', 'ö').Replace('ű', 'ü');
                int n = Szoveg.Length;
                string[] tmb = new string[n];
                for (int i = 0; i <= Szoveg.Length - 1; i++)
                {
                    tmb[i] = Szoveg.Substring(i, 1).ToLower();
                }
                string Kodolt = "";
                for (int i = 0; i < n; i++)
                {
                    foreach (var m in MorseList)
                    {
                        if (tmb[i] == m.Betu)
                        {
                            Kodolt = Kodolt + m.MorseKod + " ";
                        }
                    }
                }
                Console.WriteLine("A kódolt szöveg: {0}", Kodolt);
                /* for (int i = 0; i < n; i++)
                 { 
                   Console.WriteLine("{0}", tmb[i]);
                 }*/
            }
            
            private static void AdatokBeolvasasa()
            {
                Console.WriteLine("Morse kódok beolvasása");
                MorseList = new List<Morse>();
                var sr = new StreamReader(@"MorzeABC.txt", Encoding.UTF8);
                int db = 0;
                while (!sr.EndOfStream)
                {
                    MorseList.Add(new Morse(sr.ReadLine()));
                    db++;
                }
                sr.Close();
                if (db > 0)
                {
                    Console.WriteLine("\tSikeresen beolvasva {0} db sor", db);
                }
                else
                {
                    Console.WriteLine("\tSikertelen beolvasás");
                }
            }
        }
    }
   
