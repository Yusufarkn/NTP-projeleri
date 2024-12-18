using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTP7_1

    {
        class Çalışan
        {
            public string Ad { get; set; }

            public string SoyAd { get; set; }

            public double Maaş { get; set; }

            public string Pozisyon { get; set; }

            public virtual void BilgiYazdir()
            {
                Console.WriteLine($"Ad: {Ad} SoyAd: {SoyAd} Maaş: {Maaş} Pozisyon: {Pozisyon}");
            }
        }

        class Yazılımcı : Çalışan
        {
            public string YazılımDili { get; set; }

            public override void BilgiYazdir()
            {
                base.BilgiYazdir();
                Console.WriteLine($"Yazılım dili: {YazılımDili}");
            }
        }

        class Muhasebeci : Çalışan
        {
            public string MuhasebeYazılımı { get; set; }

            public override void BilgiYazdir()
            {
                base.BilgiYazdir();
                Console.WriteLine($"Muhasebe yazılımı: {MuhasebeYazılımı}");
            }
        }

        class Hayvan
        {
            public string Ad { get; set; }
            public string Tür { get; set; }
            public int Yaş { get; set; }

            public virtual void SesÇıkar()
            {
                Console.WriteLine("Hayvan bir ses çıkarıyor.");
            }
        }

        class Memeli : Hayvan
        {
            public string TüyRengi { get; set; }

            public override void SesÇıkar()
            {
                Console.WriteLine($"{Ad} (Tür: {Tür}) bir memeli ve ses çıkarıyor: Mırr!");
            }
        }

        class Kuş : Hayvan
        {
            public int KanatGenişliği { get; set; }

            public override void SesÇıkar()
            {
                Console.WriteLine($"{Ad} (Tür: {Tür}) bir kuş ve ses çıkarıyor: Cik cik!");
            }
        }

        class Hesap
        {
            public string HesapNumarasi { get; set; }
            public double Bakiye { get; set; }
            public string HesapSahibi { get; set; }

            public virtual void ParaYatir(double miktar)
            {
                Bakiye += miktar;
                Console.WriteLine($"{miktar} TL hesaba yatırıldı. Güncel bakiye: {Bakiye} TL");
            }

            public virtual void ParaCek(double miktar)
            {
                if (Bakiye >= miktar)
                {
                    Bakiye -= miktar;
                    Console.WriteLine($"{miktar} TL hesaptan çekildi. Güncel bakiye: {Bakiye} TL");
                }
                else
                {
                    Console.WriteLine("Yetersiz bakiye!");
                }
            }

            public virtual void BilgiYazdir()
            {
                Console.WriteLine("--- Hesap Bilgileri ---");
                Console.WriteLine($"Hesap Sahibi: {HesapSahibi}");
                Console.WriteLine($"Hesap Numarası: {HesapNumarasi}");
                Console.WriteLine($"Bakiye: {Bakiye} TL");
            }
        }

        // Vadesiz Hesap Sınıfı
        class VadesizHesap : Hesap
        {
            public double EkHesapLimiti { get; set; }

            public override void ParaCek(double miktar)
            {
                if (Bakiye + EkHesapLimiti >= miktar)
                {
                    double kalanMiktar = miktar - Bakiye;
                    if (kalanMiktar > 0)
                    {
                        Bakiye = 0;
                        EkHesapLimiti -= kalanMiktar;
                    }
                    else
                    {
                        Bakiye -= miktar;
                    }
                    Console.WriteLine($"{miktar} TL çekildi. Güncel bakiye: {Bakiye} TL, Ek Hesap Limiti: {EkHesapLimiti} TL");
                }
                else
                {
                    Console.WriteLine("Yetersiz bakiye ve ek hesap limiti!");
                }
            }

            public override void BilgiYazdir()
            {
                base.BilgiYazdir();
                Console.WriteLine($"Ek Hesap Limiti: {EkHesapLimiti} TL");
            }
        }

        // Vadeli Hesap Sınıfı
        class VadeliHesap : Hesap
        {
            public int VadeSuresi { get; set; } // Gün cinsinden
            public double FaizOrani { get; set; } // Yüzde olarak

            private bool VadeDolduMu()
            {
                return VadeSuresi <= 0;
            }

            public override void ParaCek(double miktar)
            {
                if (VadeDolduMu())
                {
                    base.ParaCek(miktar);
                }
                else
                {
                    Console.WriteLine("Vade süresi dolmadan para çekemezsiniz!");
                }
            }

            public override void BilgiYazdir()
            {
                base.BilgiYazdir();
                Console.WriteLine($"Vade Süresi: {VadeSuresi} gün");
                Console.WriteLine($"Faiz Oranı: {FaizOrani}%");
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                /*Console.WriteLine("Çalışan Pozisyonu seçiniz(1: Yazılımcı, 2: Muhasebeci): ");
                int secim = int.Parse(Console.ReadLine());

                Çalışan çalışan;

                if (secim == 1)
                {
                    çalışan = new Yazılımcı();
                    Console.WriteLine("Ad:");
                    çalışan.Ad = Console.ReadLine();
                    Console.WriteLine("SoyAd:");
                    çalışan.SoyAd = Console.ReadLine();
                    Console.WriteLine("Maaş: ");
                    çalışan.Maaş = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Pozisyon: ");
                    çalışan.Pozisyon = Console.ReadLine();
                    Console.WriteLine("Yazılım dili:");
                    ((Yazılımcı)çalışan).YazılımDili = Console.ReadLine();
                }
                else if (secim == 2)
                {
                    çalışan = new Muhasebeci();
                    Console.WriteLine("Ad:");
                    çalışan.Ad = Console.ReadLine();
                    Console.WriteLine("SoyAd:");
                    çalışan.SoyAd = Console.ReadLine();
                    Console.WriteLine("Maaş: ");
                    çalışan.Maaş = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Pozisyon: ");
                    çalışan.Pozisyon = Console.ReadLine();
                    Console.WriteLine("MuhasebeYazılımı:");
                    ((Muhasebeci)çalışan).MuhasebeYazılımı = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine(" Geçersiz seçim!Program sonlandırılıyor.");
                    return;
                }*/
                /*Console.WriteLine("Hayvan Türü seçiniz(1: Memeli,2:Kuş):");
                string seçim = Console.ReadLine();
                Hayvan hayvan;
                if (seçim == "1")
                {
                    // Memeli oluştur ve bilgilerini al
                    Memeli memeli = new Memeli();
                    Console.Write("Memelinin adını girin: ");
                    memeli.Ad = Console.ReadLine();
                    Console.Write("Memelinin türünü girin: ");
                    memeli.Tür = Console.ReadLine();
                    Console.Write("Memelinin yaşını girin: ");
                    memeli.Yaş = int.Parse(Console.ReadLine());
                    Console.Write("Memelinin tüy rengini girin: ");
                    memeli.TüyRengi = Console.ReadLine();
                }
                else if (seçim == "2")
                {
                    // Kuş oluştur ve bilgilerini al
                    Kuş kuş = new Kuş();
                    Console.Write("Kuşun adını girin: ");
                    kuş.Ad = Console.ReadLine();
                    Console.Write("Kuşun türünü girin: ");
                    kuş.Tür = Console.ReadLine();
                    Console.Write("Kuşun yaşını girin: ");
                    kuş.Yaş = int.Parse(Console.ReadLine());
                    Console.Write("Kuşun kanat genişliğini girin (cm): ");
                    kuş.KanatGenişliği = int.Parse(Console.ReadLine());

                }
                else
                {
                    Console.WriteLine("Geçersiz seçim yaptınız!");
                }*/
                Console.WriteLine("Hesap Türü seçinizn(1: Vadeli ,2:Vadesiz ):");
                string seçim = Console.ReadLine();
                Hesap hesap;

                if (seçim == "1")
                {
                    hesap = new VadesizHesap();
                    Console.Write("Hesap sahibinin adını girin: ");
                    hesap.HesapSahibi = Console.ReadLine();
                    Console.Write("Hesap numarasını girin: ");
                    hesap.HesapNumarasi = Console.ReadLine();
                    Console.Write("Başlangıç bakiyesini girin: ");
                    hesap.Bakiye = double.Parse(Console.ReadLine());
                    Console.Write("Ek hesap limitini girin: ");
                    ((VadesizHesap)hesap).EkHesapLimiti = double.Parse(Console.ReadLine());
                }
                else if (seçim == "2")
                {
                    hesap = new VadeliHesap();
                    Console.Write("Hesap sahibinin adını girin: ");
                    hesap.HesapSahibi = Console.ReadLine();
                    Console.Write("Hesap numarasını girin: ");
                    hesap.HesapNumarasi = Console.ReadLine();
                    Console.Write("Başlangıç bakiyesini girin: ");
                    hesap.Bakiye = double.Parse(Console.ReadLine());
                    Console.Write("Vade süresini girin (gün): ");
                    ((VadeliHesap)hesap).VadeSuresi = int.Parse(Console.ReadLine());
                    Console.Write("Faiz oranını girin (%): ");
                    ((VadeliHesap)hesap).FaizOrani = double.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim!");
                    return;
                }

                Console.WriteLine();
                hesap.BilgiYazdir();

                Console.WriteLine("\n1. Para Yatır");
                Console.WriteLine("2. Para Çek");
                Console.Write("Bir işlem seçin (1/2): ");
                string islemSecimi = Console.ReadLine();

                if (islemSecimi == "1")
                {
                    Console.Write("Yatırılacak miktarı girin: ");
                    double miktar = double.Parse(Console.ReadLine());
                    hesap.ParaYatir(miktar);
                }
                else if (islemSecimi == "2")
                {
                    Console.Write("Çekilecek miktarı girin: ");
                    double miktar = double.Parse(Console.ReadLine());
                    hesap.ParaCek(miktar);
                }
                else
                {
                    Console.WriteLine("Geçersiz işlem!");
                }

                Console.WriteLine("\nGüncel Hesap Bilgileri:");
                hesap.BilgiYazdir();
            }

        }
    }


