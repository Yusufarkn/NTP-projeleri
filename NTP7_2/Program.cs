
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTP7_2
{
    public abstract class Hesap : IBankaHesabi
    {
        public int HesapNo { get; set; }

        private decimal Bakiye;

        public DateTime HesapAcilisTarihi { get; set; }

        public decimal bakiye
        {
            get { return Bakiye; }
            set
            {
                if (value >= 0)
                {
                    Bakiye = value;
                }
                else
                {
                    Console.WriteLine("Bakiye negatif olamaz!");
                }
            }
        }

        public void ParaYatir(decimal M)
        {
            if (M > 0)
            {
                Bakiye += M;
                Console.WriteLine($"{M} TL hesaba yatırıldı. Güncel bakiye: {Bakiye} TL");
            }
            else
            {
                Console.WriteLine("Yatırılacak miktar sıfırdan büyük olmalıdır!");
            }
        }
        public virtual void ParaÇek(decimal M)
        {
            if (M <= Bakiye)
            {
                Bakiye -= M;
                Console.WriteLine($"{M} Tl hesaptan çekildi. Güncel bakiye: {Bakiye} TL");
            }
            else
            {
                Console.WriteLine($"Bakiye yetersiz. Lütfen daha düşük bir tutar çekmeyi deneyiniz.");
            }
        }
        public abstract void HesapOzeti();
    }
    public class BirikimHesabi : Hesap
    {
        // Faiz oranını sabit bir değere ayarlıyoruz
        private readonly decimal FaizOranı = 18;

        public decimal faizOranı
        {
            get { return FaizOranı; }
        }

        public override void HesapOzeti()
        {
            Console.WriteLine("=== Birikim Hesabı Özeti ===");
            Console.WriteLine($"Hesap Numarası: {HesapNo}");
            Console.WriteLine($"Açılış Tarihi: {HesapAcilisTarihi}");
            Console.WriteLine($"Bakiye: {bakiye} TL");
            Console.WriteLine($"Faiz Oranı: {faizOranı}%");
        }
    }


    class VadesizHesap : Hesap
    {
        public override void ParaÇek(decimal M)
        {
            decimal k = M / 1000;
            decimal İşlemÜcreti = k * 8;
            if (M <= bakiye + İşlemÜcreti)
            {
                Console.WriteLine($"{M} TL para çekildi. Güncel bakiyeniz {bakiye} TL");
            }
            else
            {
                Console.WriteLine("Bakiye Yetersiz.Lütfen daha düşük bir tutar çekmeyi deneyiniz.");
            }
        }
        public override void HesapOzeti()
        {
            Console.WriteLine("=== Vadesiz Hesap Özeti ===");
            Console.WriteLine($"Hesap Numarası: {HesapNo}");
            Console.WriteLine($"Açılış Tarihi: {HesapAcilisTarihi}");
            Console.WriteLine($"Bakiye: {bakiye} TL");
        }
    }
    public interface IBankaHesabi
    {
        DateTime HesapAcilisTarihi { get; set; }
        void HesapOzeti();
    }

    public abstract class Urun
    {
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }

        // Soyut Metot
        public abstract decimal HesaplaOdeme();

        // BilgiYazdir Metodu
        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Ürün Adı: {Ad} Fiyat: {Fiyat} TL");

        }
    }

    // Kitap Sınıfı
    public class Kitap : Urun
    {
        public string Yazar { get; set; }
        public int SayfaSayisi { get; set; }

        // Ödeme Hesaplama: %10 vergi ekleniyor
        public override decimal HesaplaOdeme()
        {
            return Fiyat + (Fiyat * 0.10m);
        }

        // BilgiYazdir Metodu
        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Yazar: {Yazar} Sayfa Sayısı: { SayfaSayisi} Ödenecek Tutar: {HesaplaOdeme()} TL");

        }
    }

    // Elektronik Sınıfı
    public class Elektronik : Urun
    {
        public string Marka { get; set; }
        public string Model { get; set; }

        // Ödeme Hesaplama: %25 vergi ekleniyor
        public override decimal HesaplaOdeme()
        {
            return Fiyat + (Fiyat * 0.25m);
        }

        // BilgiYazdir Metodu
        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Marka: {Marka} Model: {Model} Ödenecek Tutar: {HesaplaOdeme()} TL ");
        }

        public interface IYayinci
        {
            void AboneEkle(IAbone abone);
            void AboneCikar(IAbone abone);
            void BildirimGonder(string mesaj);
        }

        // IAbone Arayüzü
        public interface IAbone
        {
            void BilgiAl(string mesaj);
        }

        // Yayinci Sınıfı
        public class Yayinci : IYayinci
        {
            private List<IAbone> aboneler = new List<IAbone>();

            public void AboneEkle(IAbone abone)
            {
                aboneler.Add(abone);
                Console.WriteLine("Yeni bir abone eklendi.");
            }

            public void AboneCikar(IAbone abone)
            {
                aboneler.Remove(abone);
                Console.WriteLine("Bir abone çıkarıldı.");
            }

            public void BildirimGonder(string mesaj)
            {
                Console.WriteLine($"Yayıncı bildirimi gönderiyor: {mesaj}");
                foreach (var abone in aboneler)
                {
                    abone.BilgiAl(mesaj);
                }
            }
        }

        // Abone Sınıfı
        public class Abone : IAbone
        {
            public string Ad { get; set; }

            public Abone(string ad)
            {
                Ad = ad;
            }

            public void BilgiAl(string mesaj)
            {
                Console.WriteLine($"{Ad}, yeni bir bildirim aldı: {mesaj}");
            }
        }


        class Program
        {
            static void Main(string[] args)
            {
                VadesizHesap vadesizHesap = new VadesizHesap
                {
                    HesapNo = 735624,
                    HesapAcilisTarihi = DateTime.Now,
                    bakiye = 7500
                };

                BirikimHesabi birikimHesap = new BirikimHesabi
                {
                    HesapNo = 325645,
                    HesapAcilisTarihi = DateTime.Now,
                    bakiye = 22050,

                };

                Console.WriteLine("=== Vadesiz Hesap İşlemleri ===");
                vadesizHesap.ParaYatir(1500);
                vadesizHesap.ParaÇek(900);
                vadesizHesap.HesapOzeti();

                Console.WriteLine("\n=== Birikim Hesabı İşlemleri ===");
                birikimHesap.ParaYatir(5000);
                birikimHesap.HesapOzeti();

                // Ürün koleksiyonu oluşturuluyor
                List<Urun> urunler = new List<Urun>();

                // Kitap ve Elektronik Ürün Ekleniyor
                Kitap kitap1 = new Kitap
                {
                    Ad = "C# Programlama",
                    Fiyat = 250,
                    Yazar = "Yusuf Arıkan",
                    SayfaSayisi = 340,
                };

                Elektronik elektronik1 = new Elektronik
                {
                    Ad = "Laptop",
                    Fiyat = 50000,
                    Marka = "HP",
                    Model = "VİCTUS-16"
                };

                // Ürünler listeye ekleniyor
                urunler.Add(kitap1);
                urunler.Add(elektronik1);

                // Ürün bilgileri ekrana yazdırılıyor
                Console.WriteLine("=== Ürün Bilgileri ===\n");
                foreach (var urun in urunler)
                {
                    urun.BilgiYazdir();
                    Console.WriteLine("------------------------\n");
                }


                // Yayıncı oluşturuluyor
                Yayinci Yusuf = new Yayinci();

                // Aboneler oluşturuluyor
                Abone abone1 = new Abone("Mustafa");
                Abone abone2 = new Abone("İnci");
                Abone abone3 = new Abone("Seda");

                // Aboneler yayıncıya ekleniyor
                Yusuf.AboneEkle(abone1);
                Yusuf.AboneEkle(abone2);
                Yusuf.AboneEkle(abone3);

                // Yayıncı bir bildirim gönderiyor
                Yusuf.BildirimGonder("Yeni bir makale yayınlandı!");

                // Bir abone çıkarılıyor
                Yusuf.AboneCikar(abone2);

                // Yayıncı başka bir bildirim gönderiyor
                Yusuf.BildirimGonder("Yarın canlı yayın var!");
                Console.ReadLine();
            }
        }

    }
}



