using System;
using System.Collections.Generic;

namespace NTP2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> Diziler = new List<int>();
            int input;

            // Kullanıcıdan "0" girene kadar değer alma
            Console.WriteLine("Dizinin elemanlarını giriniz (0 girildiğinde dizi sonlanacaktır): ");
            while (true)
            {
                input = Convert.ToInt32(Console.ReadLine());
                if (input == 0)
                    break;
                Diziler.Add(input);
            }

            // Listeyi diziye çevirip sıralama yapma
            int[] Sayılar = Diziler.ToArray();
            Array.Sort(Sayılar);

            Console.WriteLine("Ardışık sayı grupları:");
            for (int i = 0; i < Sayılar.Length; i++)
            {
                int bas = Sayılar[i];

                // Ardışık grubu bulma
                while (i + 1 < Sayılar.Length && Sayılar[i + 1] == Sayılar[i] + 1)
                {
                    i++;
                }

                int son = Sayılar[i];

                // Grup tek elemandan oluşuyorsa sadece sayıyı yazdır
                if (bas == son)
                {
                    Console.WriteLine($"{bas}");
                }
                // Grubu yazdır
                else
                {
                    Console.WriteLine($"{bas}-{son}");
                }
            }

            // Programın sona erdiğini belirtmek için bekletme
            Console.ReadLine();
        }
    }
}

