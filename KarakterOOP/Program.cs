using System.ComponentModel.DataAnnotations;

namespace KarakterOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Karakter> karakterek = [];

            Beolvasas("karakterek.txt", karakterek);

            foreach (var item in karakterek)
            {
                Console.WriteLine(item);
            }
            AtlagosSzint(karakterek);
            LegmagasabbEletero(karakterek);
            ErossegRendezes(karakterek);
            Vane50(karakterek);
            Stats(karakterek);
            Top3(karakterek);
            Rangsorolas(karakterek);
            Csata(karakterek);

        }

        static void Beolvasas(string filenev, List<Karakter> karakterek)
        {
            StreamReader sr = new(filenev);
            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] szavak = sor.Split(';');

                Karakter karakter = new(szavak[0], Convert.ToInt16(szavak[1]), Convert.ToInt16(szavak[2]), Convert.ToInt16(szavak[3]));
                karakterek.Add(karakter);
            }
        }

        static void LegmagasabbEletero(List<Karakter> karakterek)
        {
            Karakter maxhp = karakterek[0];
            foreach (var item in karakterek)
            {
                if (maxhp.Eletero < item.Eletero)
                {
                    maxhp = item;
                }
            }
            Console.WriteLine($"A legtöbb életerővel rendelkező karakter: {maxhp.Nev} - {maxhp.Szint} / {maxhp.Ero}");
        }


        static void AtlagosSzint(List<Karakter> karakterek)
        {
            int ossz = 0;
            for (int i = 0; i < karakterek.Count; i++)
            {
                ossz += karakterek[i].Szint;
            }
            int Atlag = ossz / karakterek.Count;
            Console.WriteLine($"A karakterek átlagszintje: {Atlag}");

        }

        static void ErossegRendezes(List<Karakter> karakterek)
        {
            for (int i = 0; i < karakterek.Count - 1; i++)
            {
                for (int j = i + 1; j < karakterek.Count; j++)
                {
                    if (karakterek[i].Ero > karakterek[j].Ero)
                    {
                        Karakter csere = karakterek[i];
                        karakterek[i] = karakterek[j];
                        karakterek[j] = csere;
                    }
                }
            }
            Console.WriteLine("A karakterek erősségük alapján rendezve: ");
            foreach (var item in karakterek)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------");
        }

        static void Vane50(List<Karakter> karakterek)
        {
            Console.WriteLine("Megvan-e a karakternek az 50 erő?");
            bool megvanaz50 = false;
            for (int i = 0; i < karakterek.Count; i++)
            {
                if (karakterek[i].Ero >= 50)
                {
                    megvanaz50 = true;
                }
                Console.WriteLine(karakterek[i].Nev + " - " + megvanaz50);
            }
            Console.WriteLine("-----------------");
        }

        static void Stats(List<Karakter> karakterek)
        {
            int szint = 6;
            Console.WriteLine("Ezek a karakterek legalább 7-es szintűek:");
            for (int i = 0; i < karakterek.Count; i++)
            {
                if (karakterek[i].Szint > szint)
                {
                    Console.WriteLine(karakterek[i]);
                }
            }
            Console.WriteLine("-----------------");
        }

        //7. feladatra azt mondták nekem hogy Bogdán Tanárnő elmondása szerint nem kell megcsinálni mivel nem tanultuk.

        static void Top3(List<Karakter> karakterek)
        {
            for (int i = 0; i < karakterek.Count - 1; i++)
            {

                for (int j = i + 1; j < karakterek.Count; j++)
                {
                    if (karakterek[i].Eroszintkombo < karakterek[j].Eroszintkombo)
                    {
                        Karakter csere = karakterek[i];
                        karakterek[i] = karakterek[j];
                        karakterek[j] = csere;
                    }
                }
            }
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(karakterek[i]);
            }
            Console.WriteLine("-----------------");
        }

        static void Rangsorolas(List<Karakter> karakterek)
        {
            Console.WriteLine("karakterek rangsorolva az életerjük és erejük alapján: ");
            for (int i = 0; i < karakterek.Count - 1; i++)
            {
                for (int j = i + 1; j < karakterek.Count; j++)
                {
                    if (karakterek[i].Eleteroerokombo < karakterek[j].Eleteroerokombo)
                    {
                        Karakter csere = karakterek[i];
                        karakterek[i] = karakterek[j];
                        karakterek[j] = csere;
                    }
                }
            }
            foreach (var item in karakterek)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------");
        }

        static void Csata(List<Karakter> karakterek)
        {
            Random rand = new Random();

            var karakter1 = karakterek[rand.Next(karakterek.Count)];
            var karakter2 = karakterek[rand.Next(karakterek.Count)];

            string gyoztes = "";
            if (karakter1.Szint > karakter2.Szint && karakter1.Ero > karakter2.Ero)
            {
                gyoztes = karakter1.Nev;
            }
            else
            {
                gyoztes = karakter2.Nev;
            }

            Console.WriteLine($"A csatában {karakter1.Nev} és {karakter2.Nev} vesz részt");
            Console.WriteLine($"A csatában {gyoztes} győzött.");
        }
    
    }
}

