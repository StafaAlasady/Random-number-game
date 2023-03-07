using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadomNumber
{
    internal class App
    {
        public void run()
        {
            string path = @"C:\HighScores.txt";
            //här skapas ett item som heter random
            Random random = new Random();
            bool Spelaigen = true;
            bool isgissningvalid = false;
            int min = 1;
            int max = 100;
            int gissning;
            int nummer;
            int gissningar;
            string svar;

            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            

            while (Spelaigen)
            {
                gissning = 0;
                gissningar = 0;
                svar = "";
                nummer = random.Next(min, max + 1);
                while (gissning != nummer)
                {

                    Console.WriteLine("gissa en siffra mellan" + min + "-" + max + " : ");
                    if (gissning == nummer)
                    {
                        gissning = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Gissning:" + gissning);
                    }
                    else
                    {
                        isgissningvalid = int.TryParse(Console.ReadLine(), out gissning);
                    }



                    if (!isgissningvalid)
                    {
                        Console.WriteLine("fel input. skriv in en siffra din åsna mellan 1 och 100.");
                        continue;
                    }
                    if (gissning < nummer)
                    {
                        Console.WriteLine(gissning +"För låg, försök igen");
                    }
                    else if(gissning > nummer)
                    {
                        Console.WriteLine(gissning +"För högt, försök igen");
                    }
                    gissningar++;

                }
                Console.WriteLine("Nummer:"+nummer);
                Console.WriteLine("Du vann!!!");
                Console.WriteLine("Gissningar:" + gissningar);
                Console.WriteLine("Skulle du vilja spela igen bram ?(J/N)");
                svar = Console.ReadLine();
                svar = svar.ToUpper();

                if (svar == "J")
                {
                    Spelaigen = true;
                }
                else
                {
                    Spelaigen = false;
                    Console.WriteLine("Tack för att du har spelat, kom inte tillbaks");
                }
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.Write(gissningar);
                }

            }
                Console.ReadKey();
        }
    }
}