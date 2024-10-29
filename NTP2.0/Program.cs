using System;
using System.Collections.Generic;

namespace NTP2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> Aranilacaklar = new List<int>();
            int input;

            // Kullanıcıdan "0" girene kadar değer alma
            Console.WriteLine("Dizinin elemanlarını giriniz (0 girildiğinde dizi sonlanacaktır): ");
            while (true)
            {
                input = Convert.ToInt32(Console.ReadLine());
                if (input == 0)
                    break;
                Aranilacaklar.Add(input);
            }

            // Kullanıcıdan aranacak sayıyı alma
            Console.WriteLine("Aramak istediğiniz sayıyı giriniz: ");
            int s = Convert.ToInt32(Console.ReadLine());

            // Listeyi diziye çevirip sıralama yapma
            int[] AranilacakDizi = Aranilacaklar.ToArray();
            Array.Sort(AranilacakDizi);

            // Binary search için değişken tanımları
            int low = 0, high = AranilacakDizi.Length - 1;
            bool found = false;

            // Binary search algoritması
            while (low <= high)
            {
                int index = (low + high) / 2;

                if (AranilacakDizi[index] == s)
                {
                    found = true;
                    Console.WriteLine($"Aranan değer {s} bulundu: İndeks {index}");
                    Console.ReadLine();
                    break;
                }
                else if (AranilacakDizi[index] < s)
                {
                    low = index + 1;
                }
                else
                {
                    high = index - 1;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Aranan değer {s} bulunamadı.");
                Console.ReadLine();
            }
        }
    }
}
