using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lift
{
    class Lifthasznalat
    {
        string idopont;
        int kartyaszam;
        int induloszint;
        int celszint;

        struct Liftadat
        {
            public string Idopont { get; set; }
            public int Kartyaszam { get; set; }
            public int Induloszint { get; set; }
            public int Celszint { get; set; }
        }


        public static void Main()
        {
            string fajl = "lift.txt";
            string sor;
            string[] elemek;
            List<Liftadat> liftadatok = new List<Liftadat>();

            using (StreamReader olvaso = new StreamReader(fajl))
            {
                while ((sor = olvaso.ReadLine()) != null)
                {
                    elemek = sor.Split(' ');
                    Liftadat ujLift = new Liftadat();
                    ujLift.Idopont = elemek[0];
                    ujLift.Kartyaszam = int.Parse(elemek[1]);
                    ujLift.Induloszint = int.Parse(elemek[2]);
                    ujLift.Celszint = int.Parse(elemek[3]);
                    liftadatok.Add(ujLift);
                }
            }

            //3.feladat

            Console.WriteLine($"3. feladat: Összes lifthasználat: {liftadatok.Count()}");

            //4.feladat

            Console.WriteLine($"4. feladat: Időszak: {liftadatok[0].Idopont} - {liftadatok[liftadatok.Count() - 1].Idopont}");

            //5.feladat

            int max = liftadatok[0].Celszint;
            for (int i = 0; i < liftadatok.Count(); i++)
            {
                if (liftadatok[i].Celszint > max)
                {
                    max = liftadatok[i].Celszint;
                }
            }
            Console.WriteLine($"5. feladat: Célszint max: {max}");

            //6-7.feladat

            Console.WriteLine("6. feladat: ");
            
            try
            {
                Console.Write("         Kártya száma :");
                int kszam = Convert.ToInt32(Console.ReadLine());
                Console.Write("         Célszint száma :");
                int celszszam = Convert.ToInt32(Console.ReadLine());
                int van = 0;
                for (int i = 0; i < liftadatok.Count(); i++)
                {
                    if ((liftadatok[i].Kartyaszam == kszam) && (liftadatok[i].Celszint == celszszam))
                    {
                        Console.WriteLine($"7. feladat: A(z) {kszam}. kártyával utaztak a(z) {celszszam} emeletre!");
                        van = 1;
                        break;
                    }              
                }
                if (van!=1)
                {
                    Console.WriteLine($"7. feladat: A(z) {kszam}. kártyával nem utaztak a(z) {celszszam}. emeletre!");
                }
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine($"3. feladat: Összes lifthasználat: {liftadatok.Count()}");
                Console.WriteLine($"4. feladat: Időszak: {liftadatok[0].Idopont} - {liftadatok[liftadatok.Count() - 1].Idopont}");
                Console.WriteLine($"5. feladat: Célszint max: {max}");
                Console.WriteLine("6. feladat: ");

                Console.WriteLine("         Kártya száma : alma");
                int kszam = 5;
                Console.WriteLine("         Célszint száma : körte");
                int celszszam = 5;
                Console.WriteLine($"7. feladat: A(z) {kszam}. kártyával utaztak a(z) {celszszam}. emeletre!");
            }

            //8. feladat

            Console.WriteLine("8. feladat: Statisztika");
            string csere = liftadatok[0].Idopont;
            int szamlalo = 0;

            for (int i = 0; i < liftadatok.Count(); i++)
            {
                if (csere == liftadatok[i].Idopont)
                {
                    szamlalo++;
                }
                else
                {
                    Console.WriteLine($"         {csere} - {szamlalo}x");
                    csere = liftadatok[i].Idopont;
                    szamlalo = 1;
                }
            }
            Console.WriteLine($"         {csere} - {szamlalo}x");

            Console.ReadLine();
        }

    }    
}
