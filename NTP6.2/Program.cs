using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTP6._2
{
    class Kitaplik
    {
        private string[] kitaplar;

        public Kitaplik(int kapasite)
        {
            kitaplar = new string[kapasite];
        }

        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= kitaplar.Length)
                    return "Geçersiz indeks!";
                return kitaplar[index] ?? "Boş"; 
            }
            set
            {
                if (index < 0 || index >= kitaplar.Length)
                    Console.WriteLine("Geçersiz indeks!");
                else
                    kitaplar[index] = value;
            }
        }
    }
    class NotSistemi
    {
        private Dictionary<string, int> dersNotlari;

        public NotSistemi()
        {
            dersNotlari = new Dictionary<string, int>();
        }

        
        public int this[string ders]
        {
            get
            {
                if (dersNotlari.ContainsKey(ders))
                    return dersNotlari[ders];
                throw new Exception($"'{ders}' dersi bulunamadı!");
            }
            set
            {
                dersNotlari[ders] = value;
            }
        }
    }
    class SatrancTahtasi
    {
        private string[,] tahtasi;

        public SatrancTahtasi()
        {
            tahtasi = new string[8, 8];
        }

        public string this[int satir, int sutun]
        {
            get
            {
                if (satir < 0 || satir >= 8 || sutun < 0 || sutun >= 8)
                    return "Geçersiz kare!";
                return tahtasi[satir, sutun] ?? "Boş";
            }
            set
            {
                if (satir < 0 || satir >= 8 || sutun < 0 || sutun >= 8)
                    Console.WriteLine("Geçersiz kare!");
                else
                    tahtasi[satir, sutun] = value;
            }
        }
    }
    class Otopark
    {
        private string[,] parkYerleri;

        // Constructor: Kat sayısı ve her kattaki park yeri sayısı ile otopark oluşturulur.
        public Otopark(int katSayisi, int parkYeriSayisi)
        {
            parkYerleri = new string[katSayisi, parkYeriSayisi];
            for (int i = 0; i < katSayisi; i++)
            {
                for (int j = 0; j < parkYeriSayisi; j++)
                {
                    parkYerleri[i, j] = "Empty"; // Başlangıçta tüm park yerleri boş
                }
            }
        }

        // İndeksleyici: Kat ve park yeri numarasına erişim sağlar.
        public string this[int kat, int parkYeri]
        {
            get
            {
                if (kat < 0 || kat >= parkYerleri.GetLength(0) || parkYeri < 0 || parkYeri >= parkYerleri.GetLength(1))
                {
                    return "Geçersiz park yeri.";
                }
                return parkYerleri[kat, parkYeri];
            }
            set
            {
                if (kat < 0 || kat >= parkYerleri.GetLength(0) || parkYeri < 0 || parkYeri >= parkYerleri.GetLength(1))
                {
                    Console.WriteLine("Geçersiz park yeri.");
                    return;
                }
                parkYerleri[kat, parkYeri] = value;
            }
        }

        // Otopark durumu yazdırma
        public void OtoparkDurumu()
        {
            for (int i = 0; i < parkYerleri.GetLength(0); i++)
            {
                Console.WriteLine($"Kat {i + 1}:");
                for (int j = 0; j < parkYerleri.GetLength(1); j++)
                {
                    Console.Write($" {parkYerleri[i, j]} ");
                }
                Console.WriteLine();
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
