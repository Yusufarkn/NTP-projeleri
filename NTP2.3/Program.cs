using System;
using System.Data;
using System.Text.RegularExpressions;

namespace NTP2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Matematiksel ifadeyi girin (örneğin, 3 + 2^3 * 5 - 8 / 4):");
            string ifade = Console.ReadLine();
            try
            {
                // Çözüm sürecini gösterme
                ÇözümSüreciGöster(ifade);

                // Sonucu hesaplama ve gösterme
                double sonuc = Hesapla(ifade);
                Console.WriteLine("Sonuç: " + sonuc);
                Console.ReadLine(); // Sonucun ekranda kalmasını sağlar
            }
            catch (Exception ex)
            {
                Console.WriteLine("Geçersiz ifade: " + ex.Message);
                Console.ReadLine();
            }
        }

        static void ÇözümSüreciGöster(string ifade)
        {
            Console.WriteLine("\nİşlem süreci:");
            string tempIfade = ifade;

            // Üst alma işlemleri
            while (tempIfade.Contains("**"))
            {
                tempIfade = IslemiGerceklestir(tempIfade, "**");
                Console.WriteLine(tempIfade);
                Console.ReadLine(); // Adım adım işlem için bekletme
            }

            // Çarpma ve bölme işlemleri
            while (tempIfade.Contains("*") || tempIfade.Contains("/"))
            {
                tempIfade = IslemiGerceklestir(tempIfade, "*", "/");
                Console.WriteLine(tempIfade);
                Console.ReadLine();
            }

            // Toplama ve çıkarma işlemleri
            while (tempIfade.Contains("+") || tempIfade.Contains("-"))
            {
                tempIfade = IslemiGerceklestir(tempIfade, "+", "-");
                Console.WriteLine(tempIfade);
                Console.ReadLine();
            }
        }

        static string IslemiGerceklestir(string ifade, params string[] islemler)
        {
            foreach (string islem in islemler)
            {
                var pattern = $@"(-?\d+(\.\d+)?)\s*{Regex.Escape(islem)}\s*(-?\d+(\.\d+)?)";
                var match = Regex.Match(ifade, pattern);

                if (match.Success)
                {
                    double solSayi = Convert.ToDouble(match.Groups[1].Value);
                    double sagSayi = Convert.ToDouble(match.Groups[3].Value);

                    double sonuc;
                    if (islem == "**")
                    {
                        sonuc = Math.Pow(solSayi, sagSayi);
                    }
                    else if (islem == "*")
                    {
                        sonuc = solSayi * sagSayi;
                    }
                    else if (islem == "/")
                    {
                        sonuc = solSayi / sagSayi;
                    }
                    else if (islem == "+")
                    {
                        sonuc = solSayi + sagSayi;
                    }
                    else if (islem == "-")
                    {
                        sonuc = solSayi - sagSayi;
                    }
                    else
                    {
                        sonuc = 0;
                    }

                    ifade = ifade.Replace(match.Value, sonuc.ToString());
                    break;
                }
            }
            return ifade;
        }

        static double Hesapla(string ifade)
        {
            DataTable dt = new DataTable();
            // Güvenlik amacıyla ^ sembolünü ** ile değiştir
            ifade = ifade.Replace("^", "**");
            var sonuc = dt.Compute(ifade, "");
            return Convert.ToDouble(sonuc);
        }
    }
}

