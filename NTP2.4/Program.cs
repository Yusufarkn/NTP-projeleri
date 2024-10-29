using System;

namespace NTP2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("İlk polinomu girin (örneğin, 3x^2 + 4x - 8):");
                string polinom1 = Console.ReadLine();
                if (polinom1.ToLower() == "exit") break;

                Console.WriteLine("İkinci polinomu girin (örneğin, 5x^2 - 2):");
                string polinom2 = Console.ReadLine();
                if (polinom2.ToLower() == "exit") break;

                int[] katsayılar1 = ParsePolinom(polinom1);
                int[] katsayılar2 = ParsePolinom(polinom2);

                int[] toplam = { katsayılar1[0] + katsayılar2[0], katsayılar1[1] + katsayılar2[1], katsayılar1[2] + katsayılar2[2] };
                int[] fark = { katsayılar1[0] - katsayılar2[0], katsayılar1[1] - katsayılar2[1], katsayılar1[2] - katsayılar2[2] };

                Console.WriteLine("Polinomların toplamı: " + PolinomToString(toplam));
                Console.WriteLine("Polinomların farkı: " + PolinomToString(fark));
                Console.ReadLine();
                break;
            }
        }

        static int[] ParsePolinom(string polinom)
        {
            int[] katsayılar = new int[3];
            polinom = polinom.Replace(" ", "").Replace("-", "+-"); // '-' işaretlerini ayırma
            string[] terimler = polinom.Split('+');
            foreach (string terim in terimler)
            {
                if (terim.Contains("x^2"))
                {
                    katsayılar[0] += GetKatsayi(terim, "x^2");
                }
                else if (terim.Contains("x"))
                {
                    katsayılar[1] += GetKatsayi(terim, "x");
                }
                else if (!string.IsNullOrEmpty(terim))
                {
                    katsayılar[2] += int.Parse(terim);
                }
            }
            return katsayılar;
        }

        static int GetKatsayi(string terim, string degisken)
        {
            string katsayiStr = terim.Replace(degisken, "");
            return katsayiStr == "" || katsayiStr == "+" ? 1 : (katsayiStr == "-" ? -1 : int.Parse(katsayiStr));
        }

        static string PolinomToString(int[] katsayilar)
        {
            string sonuc = "";
            if (katsayilar[0] != 0) sonuc += $"{katsayilar[0]}x^2 ";
            if (katsayilar[1] != 0) sonuc += $"{(katsayilar[1] > 0 && sonuc != "" ? "+" : "")}{katsayilar[1]}x ";
            if (katsayilar[2] != 0) sonuc += $"{(katsayilar[2] > 0 && sonuc != "" ? "+" : "")}{katsayilar[2]}";
            return sonuc == "" ? "0" : sonuc.Trim();
        }
    }
}

