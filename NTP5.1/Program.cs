using System;
using System.Collections.Generic;


namespace NTP5._1
{
    class Yazar
    {
        public string Ad { get; set; }
        public string Ülke { get; set; }
        public List<Kitap> Kitaplar { get; set; }

        // Constructor
        public Yazar(string ad, string ülke)
        {
            Ad = ad; // 'this' kullanımı gerekli değil, parametre isimleri farklı.
            Ülke = ülke;
            Kitaplar = new List<Kitap>(); // Liste başlatılıyor.
        }

        // Kitap ekleme metodu
        public void KitapEkle(Kitap kitap)
        {
            Kitaplar.Add(kitap); // Listeye kitap ekleniyor.
        }
    }

    class Kitap
    {
        public string Başlık { get; set; }
        public string ISBN { get; set; }

        // Constructor
        public Kitap(string başlık, string isbn)
        {
            Başlık = başlık;
            ISBN = isbn;
        }
    }

    class Departman
    {
        public string Ad { get; set; }
        public string Lokasyon { get; set; }

        public Departman(string ad, string lokasyon)
        {
            Ad = ad;
            Lokasyon = lokasyon;
        }
    }

    class Çalışan
    {
        public string Ad { get; set; }
        public string Pozisyon { get; set; }
        public Departman Departman { get; set; }

        public Çalışan(string ad, string pozisyon, Departman departman)
        {
            Ad = ad;
            Pozisyon = pozisyon;
            Departman = departman;
        }

        public void DepartmanAtama(Departman departman)
        {
            Departman = departman;
        }
    }

    class Ürün
    {
        public string Ad { get; set; }
        public int Fiyat { get; set; }

        public Ürün(string ad, int fiyat)
        {
            Ad = ad;
            Fiyat = fiyat;
        }

        public void ÜrünBilgisi()
        {
            Console.WriteLine($"Ürün: {Ad}, Fiyat: {Fiyat} TL");
        }
    }

    class Sipariş
    {
        public DateTime Tarih { get; set; }
        public decimal Toplam { get; set; }
        public List<Ürün> Ürünler { get; set; }

        public Sipariş(DateTime tarih)
        {
            Tarih = tarih;
            Ürünler = new List<Ürün>();
            Toplam = 0;
        }

        public void ÜrünEkle(Ürün ürün)
        {
            Ürünler.Add(ürün);
            Toplam += ürün.Fiyat;
        }

        public void SiparişBilgisi()
        {
            Console.WriteLine($"Sipariş Tarihi: {Tarih}, Toplam: {Toplam} TL");
            Console.WriteLine("Siparişe Eklenen Ürünler:");
            foreach (var ürün in Ürünler)
            {
                ürün.ÜrünBilgisi();
            }
        }
    }
    class Müşteri
    {
        public string Ad { get; set; }
        public string Telefon { get; set; }
        public List<Sipariş> Siparişler { get; set; }

        public Müşteri(string ad, string telefon)
        {
            Ad = ad;
            Telefon = telefon;
            Siparişler = new List<Sipariş>();
        }

        public void SiparişVer(Sipariş sipariş)
        {
            Siparişler.Add(sipariş);
        }

        public void MüşteriBilgisi()
        {
            Console.WriteLine($"Müşteri: {Ad}, Telefon: {Telefon}");
            Console.WriteLine("Siparişler:");
            foreach (var sipariş in Siparişler)
            {
                sipariş.SiparişBilgisi();
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
