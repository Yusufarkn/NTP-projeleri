using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTP6._4
{
    enum TrafikIsigi
    {
        Red,
        Yellow,
        Green
    }

    class TrafikKontrol
    {
        public string NeYapmali(TrafikIsigi durum)
        {
            switch (durum)
            {
                case TrafikIsigi.Red:
                    return "Dur!";
                case TrafikIsigi.Yellow:
                    return "Hazırlan!";
                case TrafikIsigi.Green:
                    return "Geç!";
                default:
                    return "Bilinmeyen durum.";
            }
        }
    }
    enum HavaDurumu
    {
        Sunny,
        Rainy,
        Cloudy,
        Stormy
    }

    class HavaTahmini
    {
        public string TavsiyeVer(HavaDurumu durum)
        {
            switch (durum)
            {
                case HavaDurumu.Sunny:
                    return "Hava güneşli, dışarı çıkabilir ve güneş gözlüğü alabilirsiniz.";
                case HavaDurumu.Rainy:
                    return "Yağmur yağıyor, şemsiye alın.";
                case HavaDurumu.Cloudy:
                    return "Hava bulutlu, yağmur ihtimaline karşı hazırlıklı olun.";
                case HavaDurumu.Stormy:
                    return "Fırtına var, evde kalmak en iyisi.";
                default:
                    return "Bilinmeyen hava durumu.";
            }
        }
    }
    enum CalisanRol
    {
        Manager,
        Developer,
        Designer,
        Tester
    }

    class MaasHesaplama
    {
        public double MaasHesapla(CalisanRol rol)
        {
            switch (rol)
            {
                case CalisanRol.Manager:
                    return 15000; // Yönetici maaşı
                case CalisanRol.Developer:
                    return 12000; // Yazılım geliştirici maaşı
                case CalisanRol.Designer:
                    return 10000; // Tasarımcı maaşı
                case CalisanRol.Tester:
                    return 8000;  // Test uzmanı maaşı
                default:
                    return 0;     // Bilinmeyen rol
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
