using System;
using System.Collections.Generic;
using System.Linq;

namespace NTPproje2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> sayilar = new List<double>(); // Girilen sayıları tutmak için List
            double toplam = 0;

            while (true)
            {
                Console.WriteLine("Pozitif bir sayı giriniz (0 girilirse hesaplama sonlanır): ");
                double n = Convert.ToDouble(Console.ReadLine());

                if (n == 0 )
                {
                    // 0 girildiğinde hesaplamayı sonlandır
                    if (sayilar.Count > 0) // Girilen sayı varsa hesapla
                    {
                        double ortalama = toplam / sayilar.Count;

                        // Medyan hesaplama
                        sayilar.Sort(); // Küçükten büyüğe doğru sıralama
                        double medyan;
                        if (sayilar.Count % 2 == 1)
                        {
                            // Tek sayı varsa ortadaki eleman
                            medyan = sayilar[sayilar.Count / 2];
                        }
                        else
                        {
                            // Çift sayıda eleman varsa ortadaki iki elemanın ortalaması
                            double orta1 = sayilar[(sayilar.Count / 2) - 1];
                            double orta2 = sayilar[sayilar.Count / 2];
                            medyan = (orta1 + orta2) / 2;
                        }

                        Console.WriteLine($"Girilen sayıların ortalaması: {ortalama}");
                        Console.WriteLine($"Girilen sayıların medyanı: {medyan}");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Hiç sayı girilmedi.");
                    }
                    break; // Döngüyü sonlandır
                }
                else if (n < 0) // Negatif sayı mı
                {
                    Console.WriteLine("Pozitif bir sayı giriniz!");
                    continue;
                }

                sayilar.Add(n); // Girilen sayıyı Liste ekleme
                toplam += n;
            }
        }
    }
}
