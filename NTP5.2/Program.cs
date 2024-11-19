using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTP5._2
{
    class Doktor
    {
        public string Ad { get; set; }
        public string Branş { get; set; }
        public List<Hasta> Hastalar { get; set; }

        public Doktor(string ad, string branş)
        {
            Ad = ad;
            Branş = branş;
            Hastalar = new List<Hasta>();
        }

        public void HastaEkle(Hasta hasta)
        {
            Hastalar.Add(hasta);
        }
    }

    class Hasta
    {
        public string Ad { get; set; }
        public string TCNo { get; set; }
        public List<Doktor> Doktorlar { get; set; }

        public Hasta(string ad, string tcNo)
        {
            Ad = ad;
            TCNo = tcNo;
            Doktorlar = new List<Doktor>();
        }

        public void DoktorAtama(Doktor doktor)
        {
            Doktorlar.Add(doktor);
        }
    }


    class Yazar
    {
        public string Ad { get; set; }
        public string Ülke { get; set; }
        public List<Kitap> Kitaplar { get; set; }

        public Yazar(string ad, string ülke)
        {
            Ad = ad;
            Ülke = ülke;
            Kitaplar = new List<Kitap>();
        }

        public void KitapEkle(Kitap kitap)
        {
            Kitaplar.Add(kitap);
        }
    }

    class Kitap
    {
        public string Başlık { get; set; }
        public DateTime YayınTarihi { get; set; }
        public Yazar Yazar { get; set; }

        public Kitap(string başlık, DateTime yayınTarihi, Yazar yazar)
        {
            Başlık = başlık;
            YayınTarihi = yayınTarihi;
            Yazar = yazar;
        }
    }

    class Şirket
    {
        public string Ad { get; set; }
        public string Konum { get; set; }
        public List<Çalışan> Çalışanlar { get; set; }

        public Şirket(string ad, string konum)
        {
            Ad = ad;
            Konum = konum;
            Çalışanlar = new List<Çalışan>();
        }

        public void ÇalışanEkle(Çalışan çalışan)
        {
            Çalışanlar.Add(çalışan);
        }
    }

    class Çalışan
    {
        public string İsim { get; set; }
        public List<Şirket> Şirketler { get; set; }

        public Çalışan(string isim)
        {
            İsim = isim;
            Şirketler = new List<Şirket>();
        }

        public void ŞirketAtama(Şirket şirket)
        {
            Şirketler.Add(şirket);
        }
    }


    class Ebeveyn
    {
        public string Ad { get; set; }
        public int Yaş { get; set; }
        public List<Çocuk> Çocuklar { get; set; }

        public Ebeveyn(string ad, int yaş)
        {
            Ad = ad;
            Yaş = yaş;
            Çocuklar = new List<Çocuk>();
        }

        public void ÇocukEkle(Çocuk çocuk)
        {
            Çocuklar.Add(çocuk);
        }
    }

    class Çocuk
    {
        public string Ad { get; set; }
        public int Yaş { get; set; }
        public Ebeveyn Ebeveyn { get; set; }

        public Çocuk(string ad, int yaş, Ebeveyn ebeveyn)
        {
            Ad = ad;
            Yaş = yaş;
            Ebeveyn = ebeveyn;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
