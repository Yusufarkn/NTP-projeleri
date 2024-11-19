using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTP5._4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace NTP5_4
    {
        class Islemci
        {
            private int cekirdekler;
            private int frekans;

            public Islemci(int cekirdekler, int frekans)
            {
                this.cekirdekler = cekirdekler;
                this.frekans = frekans;
            }

            public String islemciBilgisi()
            {
                return "Çekirdek Sayısı: " + cekirdekler + ", Frekans: " + frekans + "GHz";
            }
        }

        class Bilgisayar
        {
            private String model;
            private Islemci islemci;

            public Bilgisayar(String model, int cekirdekler, int frekans)
            {
                this.model = model;
                this.islemci = new Islemci(cekirdekler, frekans); // Bileşim
            }



        }

        class Motor
        {
            private int guc;
            private String tip;

            public Motor(int guc, String tip)
            {
                this.guc = guc;
                this.tip = tip;
            }

            public String motorBilgisi()
            {
                return "Güç: " + guc + "HP, Tip: " + tip;
            }
        }

        class Otomobil
        {
            private String marka;
            private Motor motor;

            public Otomobil(String marka, int guc, String tip)
            {
                this.marka = marka;
                this.motor = new Motor(guc, tip); // Bileşim
            }
        }

        class Ogrenci
        {
            private String ad;
            private int yas;

            public Ogrenci(String ad, int yas)
            {
                this.ad = ad;
                this.yas = yas;
            }

            public String ogrenciBilgisi()
            {
                return "Ad: " + ad + ", Yaş: " + yas;
            }
        }

        class Okul
        {
            private String ad;
            private List<Ogrenci> ogrenciler;

            public Okul(String ad)
            {
                this.ad = ad;
                this.ogrenciler = new List<Ogrenci>();
            }

            public void ogrenciEkle(Ogrenci ogrenci)
            {
                ogrenciler.Add(ogrenci); // Bağımlılık
            }


        }

    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
