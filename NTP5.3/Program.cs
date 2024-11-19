using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTP5._3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace NTP5_3
    {
        class Ev
        {
            public string Ad { get; set; }
            public List<Oda> Odalar { get; set; }

            // Constructor
            public Ev(string ad)
            {
                Ad = ad;
                Odalar = new List<Oda>();
            }

            // Oda ekleme metodu
            public void OdaEkle(string boyut, string tip)
            {
                Oda yeniOda = new Oda(boyut, tip);
                Odalar.Add(yeniOda);
            }
        }

        class Oda
        {
            public string Boyut { get; set; }
            public string Tip { get; set; }

            // Constructor
            public Oda(string boyut, string tip)
            {
                Boyut = boyut;
                Tip = tip;
            }
        }

        class Sirket
        {
            public string Ad { get; set; }
            public List<Calisan> Calisanlar { get; set; }

            // Constructor
            public Sirket(string ad)
            {
                Ad = ad;
                Calisanlar = new List<Calisan>();
            }

            // Çalışan ekleme metodu
            public void CalisanEkle(Calisan calisan)
            {
                Calisanlar.Add(calisan);
            }
        }

        class Calisan
        {
            public string Ad { get; set; }
            public string Pozisyon { get; set; }

            // Constructor
            public Calisan(string ad, string pozisyon)
            {
                Ad = ad;
                Pozisyon = pozisyon;
            }

            // Çalışan bilgisi metodu
            public string CalisanBilgisi()
            {
                return $"Ad: {Ad}, Pozisyon: {Pozisyon}";
            }
        }

        class Kutuphane
        {
            public string Ad { get; set; }
            public List<Kitap> Kitaplar { get; set; }

            // Constructor
            public Kutuphane(string ad)
            {
                Ad = ad;
                Kitaplar = new List<Kitap>();
            }

            // Kitap ekleme metodu
            public void KitapEkle(Kitap kitap)
            {
                Kitaplar.Add(kitap);
            }
        }

        class Kitap
        {
            public string Baslik { get; set; }
            public string Yazar { get; set; }

            // Constructor
            public Kitap(string baslik, string yazar)
            {
                Baslik = baslik;
                Yazar = yazar;
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
