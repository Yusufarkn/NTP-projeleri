using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTP6._1
{
    class MatematikselIslemler
    {
        public static int Topla(int a, int b)
        {
            return a + b;
        }

        public static int Topla(int a, int b, int c)
        {
            return a + b + c;
        }

        public static int Topla(int[] sayilar)
        {
            int toplam = 0;
            foreach (int sayi in sayilar)
            {
                toplam += sayi;
            }
            return toplam;
        }
    }
    class SekilAlanlari
    {
        // Kare alanı (bir kenar uzunluğu verilerek)
        public static double Alan(double kenar)
        {
            return kenar * kenar;
        }

        // Dikdörtgen alanı (iki kenar uzunluğu verilerek)
        public static double Alan(double uzunluk, double genislik)
        {
            return uzunluk * genislik;
        }

        // Daire alanı (yarıçap verilerek)
        public static double Alan(double yaricap, bool daire)
        {
            return Math.PI * yaricap * yaricap; 
        }
    }
    class ZamanFarki
    {
        // Gün cinsinden fark döndürür
        public static int Fark(DateTime tarih1, DateTime tarih2)
        {
            return (tarih2 - tarih1).Days;
        }

        // Saat cinsinden fark döndürür
        public static double FarkSaat(DateTime tarih1, DateTime tarih2)
        {
            return (tarih2 - tarih1).TotalHours;
        }

        // Yıl, Ay ve Gün cinsinden fark döndürür
        public static (int Yil, int Ay, int Gun) FarkDetayli(DateTime tarih1, DateTime tarih2)
        {
            
            int yil = tarih2.Year - tarih1.Year;
            int ay = tarih2.Month - tarih1.Month;
            int gun = tarih2.Day - tarih1.Day;

            if (gun < 0)
            {
                ay--;
                gun += DateTime.DaysInMonth(tarih1.Year, tarih1.Month);
            }

            if (ay < 0)
            {
                yil--;
                ay += 12;
            }

            return (yil, ay, gun);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
