using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using balkezesek.Properties;

namespace balkezesek
{
    class Program
    {
        static List<Baseball> adatok = new List<Baseball>();
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Beolvasas();
            Feladat3();
            Feladat4();
            Feladat5_6();
            Console.ReadLine();
        }
        private static void Beolvasas() => Resource.balkezesek.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Skip(1).ToList().ForEach(a => adatok.Add(new Baseball(a)));
        private static void Feladat3() => Console.WriteLine($"3. feladat: {adatok.Count}");
        private static void Feladat4()
        {
            Console.WriteLine("4. feladat:");
            adatok.Where(x=>x.Utolso.ToString("yyyy-MM").Contains("1999-10")).ToList().ForEach(x => Console.WriteLine($"\t{x.Nev} {Math.Round(x.Magassag * 2.54, 1)} cm"));
        }
        private static void Feladat5_6() 
        {
            //Feladat:5
            bool BenneVan = false;
            int BevittSzam = 0;
            Console.WriteLine("5. feladat:");
            Console.Write("Kérek egy 1990 és 1999 közötti évszámot!: ");
            while (BenneVan == false)
            {
                BevittSzam = Convert.ToInt32(Console.ReadLine());
                if (BevittSzam >= 1990 && BevittSzam <= 1999)
                {
                    BenneVan = true;
                    Console.WriteLine("Ügyes vagy:)");
                }
                else
                {
                    Console.Write("Hibás adat kérek egy 1990 és 1999 közötti évszámot!:");
                }
            }
            //Feladat:6
            double OsszSuly = 0;
            double Darab = 0;
            for (int i = 0; i < adatok.Count; i++)
            {
                if (BevittSzam >= adatok[i].Elso.Year && BevittSzam <=adatok[i].Utolso.Year)
                {
                    OsszSuly += adatok[i].Suly;
                    Darab++;
                }
            }
            double Atlag = OsszSuly / Darab;
            Console.WriteLine($"6. feladat:{Math.Round(Atlag, 2)} font ");
        }
    }
    class Baseball
    {
        public Baseball(string sor)
        {
            string[] sorelemek = sor.Split(';');
            this.Nev = sorelemek[0];
            this.Elso = Convert.ToDateTime(sorelemek[1]);
            this.Utolso = Convert.ToDateTime(sorelemek[2]);
            this.Suly = Convert.ToInt32(sorelemek[3]);
            this.Magassag = Convert.ToDouble(sorelemek[4]);
        }
        public string Nev { get; set; }
        public DateTime Elso { get; set; }
        public DateTime Utolso { get; set; }
        public int Suly { get; set; }
        public double Magassag { get; set; }
    }
}
