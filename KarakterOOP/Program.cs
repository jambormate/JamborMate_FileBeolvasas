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

		}

		static void Beolvasas(string filenev, List<Karakter> karakterek)
		{
			StreamReader sr = new(filenev);
			sr.ReadLine();

			while (!sr.EndOfStream)
			{
				string sor = sr.ReadLine();
				string[] szavak = sor.Split(';');

				Karakter karakter = new (szavak[0], Convert.ToInt16(szavak[1]), Convert.ToInt16(szavak[2]), Convert.ToInt16(szavak[3]));
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
            Console.WriteLine($"{maxhp.Nev} - {maxhp.Szint} / {maxhp.Ero}");
        }
		

		static void AtlagosSzint(List<Karakter> karakterek)
		{
			int ossz = 0;
            for (int i = 0; i < karakterek.Count; i++)
            {
				ossz += karakterek[i].Szint;
            }
			int Atlag = ossz/karakterek.Count;
            Console.WriteLine($"A karakterek átlagszintje: {Atlag}");

        }
	}
}
