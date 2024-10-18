using System;


namespace NTPDers1._3
{
    class Program
    {
         
        static void Main(string[] args)
        {
            int sonuc = 0;
            Console.WriteLine("Bir sayı giriniz: ");
            int n = int.Parse(Console.ReadLine());
            if (n < 2)
            {
                Console.WriteLine("Sonuç:" + sonuc);
                Console.ReadLine();
            }
           
            for (int i = 2; i <= n; i++)
            {
                if (AsalMi(i))
                {
                    sonuc += i;
                }
            }
            Console.WriteLine("1 den girdiğiniz sayıya kadar asal olan sayıların toplamı:" + sonuc);
            Console.ReadLine();
        }
        // Asal sayı kontrol fonksiyonu
        static bool AsalMi(int sayi)
        {

            for (int i = 2; i*i <= sayi; i++)
            {
                if (sayi % i == 0)
                    return false;
            }
            return true;
        }
    }
}
