using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTP6._3
{
    struct Zaman
    {
        public int Saat { get; private set; }
        public int Dakika { get; private set; }

        // Yapıcı metot (Constructor)
        public Zaman(int saat, int dakika)
        {
            if (saat < 0 || saat > 23)
                saat = 0;
            if (dakika < 0 || dakika > 59)
                dakika = 0;

            Saat = saat;
            Dakika = dakika;
        }

        // Toplam dakika değeri döndüren metot
        public int ToplamDakika()
        {
            return Saat * 60 + Dakika;
        }

        // İki Zaman nesnesi arasındaki farkı (dakika olarak) hesaplayan metot
        public static int Fark(Zaman z1, Zaman z2)
        {
            return Math.Abs(z1.ToplamDakika() - z2.ToplamDakika());
        }
    }
    struct KarmasikSayi
    {
        public double Gercek { get; private set; }
        public double Sanal { get; private set; }

        public KarmasikSayi(double gercek, double sanal)
        {
            Gercek = gercek;
            Sanal = sanal;
        }

        // Toplama işlemi
        public KarmasikSayi Topla(KarmasikSayi diger)
        {
            return new KarmasikSayi(this.Gercek + diger.Gercek, this.Sanal + diger.Sanal);
        }

        // Çıkarma işlemi
        public KarmasikSayi Cikar(KarmasikSayi diger)
        {
            return new KarmasikSayi(this.Gercek - diger.Gercek, this.Sanal - diger.Sanal);
        }

        // ToString metodu
        public override string ToString()
        {
            return $"{Gercek} + {Sanal}i";
        }
    }
    struct Konum
    {
        public double Enlem { get; private set; }
        public double Boylam { get; private set; }

        public Konum(double enlem, double boylam)
        {
            Enlem = enlem;
            Boylam = boylam;
        }

        // Haversine Formülü ile mesafe hesaplama
        public static double Mesafe(Konum k1, Konum k2)
        {
            const double YariCap = 6371; // Dünya yarıçapı (km)
            double radianEnlem1 = DereceyiRadianaCevir(k1.Enlem);
            double radianEnlem2 = DereceyiRadianaCevir(k2.Enlem);
            double deltaEnlem = DereceyiRadianaCevir(k2.Enlem - k1.Enlem);
            double deltaBoylam = DereceyiRadianaCevir(k2.Boylam - k1.Boylam);

            double a = Math.Sin(deltaEnlem / 2) * Math.Sin(deltaEnlem / 2) +
                       Math.Cos(radianEnlem1) * Math.Cos(radianEnlem2) *
                       Math.Sin(deltaBoylam / 2) * Math.Sin(deltaBoylam / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return YariCap * c; // Mesafe (km)
        }

        private static double DereceyiRadianaCevir(double derece)
        {
            return derece * (Math.PI / 180);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
