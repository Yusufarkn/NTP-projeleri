using System;
using System.Collections.Generic;

namespace NTP4._1
{
    public class Banka
    {
        public string HesapNumarası { get; set; }

        private decimal bakiye;

        public decimal Bakiye
        {
            get { return bakiye; }
            set
            {
                if (value >= 0)
                {
                    bakiye = value;
                }
                else
                {
                    throw new ArgumentException("Bakiye negatif olamaz.");
                }
            }
        }

        public Banka(string hesapNumarası, decimal bakiye)
        {
            HesapNumarası = hesapNumarası;
            Bakiye = bakiye;
        }

        public void BakiyeGöster() => Console.WriteLine($"Hesap Numarası: {HesapNumarası}, Bakiye: {Bakiye}");

        public void ParaYatır(decimal yatır)
        {
            if (yatır > 0)
                Bakiye += yatır;
            else
                throw new ArgumentException("Yatırılan miktar pozitif olmalıdır.");
        }

        public void ParaÇek(decimal çek)
        {
            if (çek > 0 && çek <= Bakiye)
                Bakiye -= çek;
            else
                throw new ArgumentException("Çekilen miktar bakiye ile uyumsuz veya pozitif değil.");
        }
    }
    public class Ürün
    {
        public string ÜrünAd { get; set; }
        public decimal Fiyat { get; private set; } // Fiyat, indirim dışında değiştirilemez
        private decimal indirim;

        public decimal Indirim
        {
            get { return indirim; }
            set
            {
                if (value >= 0 && value <= 50)
                {
                    indirim = value;
                    Fiyat -= Fiyat * indirim / 100; // Fiyat indirim uygulanarak güncellenir
                }
                else
                {
                    throw new ArgumentException("İndirim negatif ya da %50'nin üzerinde olamaz.");
                }
            }
        }

        public Ürün(string ürünAd, decimal fiyat, decimal indirim)
        {
            this.ÜrünAd = ürünAd;
            this.Fiyat = fiyat;
            this.Indirim = indirim; // indirim özelliğine atama yapılır
        }

        public void Ürünİçerik()
        {
            Console.WriteLine($"Ürünün Adı: {ÜrünAd}, Fiyat: {Fiyat}");
        }
    }

    public class KiralikArac
    {
        public string Plaka { get; set; }
        private decimal GunlukUcret;
        public bool MusaitMi { get; private set; } = true; // Varsayılan olarak true

        public decimal gunlukUcret
        {
            get { return GunlukUcret; }
            set
            {
                if (value > 0)
                {
                    GunlukUcret = value;
                }
                else
                {
                    throw new ArgumentException("Günlük ücret negatif ya da 0 olamaz.");
                }
            }
        }

        public KiralikArac(string plaka, decimal gunlukUcret)
        {
            Plaka = plaka;
            this.GunlukUcret = gunlukUcret;
        }

        public void AraciKirala()
        {
            MusaitMi = false;
        }

        public void AraciTeslimEt()
        {
            MusaitMi = true;
        }

        public void AracBilgisi()
        {
            Console.WriteLine($"Plaka: {Plaka}, Günlük Ücret: {GunlukUcret}, Müsaitlik Durumu: {MusaitMi}");
        }
    }


    public class Kişi
    {
        public string Ad { get; set; }
        public string SoyAd { get; set; }
        public string TelefonNumarasi { get; set; }

        public Kişi(string Ad, string SoyAd, string TelefonNumarasi)
        {
            this.Ad = Ad;  // 'this' kullanılarak parametreler sınıf özelliklerine atanıyor
            this.SoyAd = SoyAd;
            this.TelefonNumarasi = TelefonNumarasi;
        }

        public void KişiBilgisi()
        {
            Console.WriteLine($"Ad: {Ad} SoyAd: {SoyAd} Telefon Numarası: {TelefonNumarasi}");
        }
    }
    public class Kitap
    {
        public string Ad { get; set; }
        public string Yazar { get; set; }
        public int SayfaSayisi { get; set; }

        public Kitap(string ad, string yazar, int sayfaSayisi)
        {
            Ad = ad;
            Yazar = yazar;
            SayfaSayisi = sayfaSayisi;
        }
    }

    public class Kütüphane
    {
        public List<Kitap> Kitaplar { get; set; }

        // Yapıcı metod: Kitaplar listesi boş olarak başlatılıyor
        public Kütüphane()
        {
            Kitaplar = new List<Kitap>();
        }

        // Yeni kitap ekleme ve kitapları listeleme
        public void KitapEkle(Kitap yeniKitap)
        {
            Kitaplar.Add(yeniKitap);
            Console.WriteLine($"'{yeniKitap.Ad}' adlı kitap bu kütüphaneye eklenmiştir.");

            // Eklenen kitabın bu kütüphaneye ait olduğunu belirtmek için this anahtar kelimesi kullanılıyor
            Console.WriteLine("Eklenen kitap bu kütüphaneye aittir: " + this);
            KitaplariListele();
        }

        // Tüm kitapları listeleyen metod
        public void KitaplariListele()
        {
            Console.WriteLine("\nKütüphanedeki Kitaplar:");
            foreach (var kitap in Kitaplar)
            {
                Console.WriteLine($"Kitap Adı: {kitap.Ad}, Yazar: {kitap.Yazar}, Sayfa Sayısı: {kitap.SayfaSayisi}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*try
            {
                Banka hesap = new Banka("25236219", 5250); // Başlangıç bakiyesi ile hesap oluşturma
                hesap.BakiyeGöster();

                hesap.ParaYatır(1200);
                hesap.BakiyeGöster();

                hesap.ParaÇek(3000);
                hesap.BakiyeGöster();

                hesap.ParaÇek(7150); // Bu işlem bakiyeden büyük olduğu için hata verecek.
                hesap.BakiyeGöster();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Beklenmeyen bir hata oluştu: " + ex.Message);
            }
            Console.ReadLine(); // Sonucun ekranda kalmasını sağlar*/
            /*try
            {
                Ürün ürün = new Ürün("Masa",3500,20);
                ürün.Ürünİçerik();
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }
            Console.ReadLine();*/

            try
            {
                KiralikArac araç = new KiralikArac("23 YPS 1903",2500);
                araç.AraciKirala();
                araç.AracBilgisi();
                araç.AraciTeslimEt();
                araç.AracBilgisi();
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }
            Console.ReadLine();

            /*Kişi kişi = new Kişi("Yusuf","Arıkan","05416233223");
            kişi.KişiBilgisi();
            Console.ReadLine();*/
            /*Kütüphane kütüphane = new Kütüphane();

            // Yeni kitap ekliyoruz
            Kitap kitap1 = new Kitap("Hayvan Çiftliği", "George Orwell", 1225);
            kütüphane.KitapEkle(kitap1);

            // Başka bir kitap daha ekliyoruz
            Kitap kitap2 = new Kitap("Suç ve Ceza", "Fyodor Dostoyevski", 672);
            kütüphane.KitapEkle(kitap2);

            Console.ReadLine();*/
            
        }
    }
}

