using System;
using System.Collections.Generic;


namespace MayinTarlasi
{


    class MayinTarlasi
    {
        static int boyut = 20; // Oyun tahtası boyutu
        static int mayinSayisi = 40; // Toplam mayın sayısı
        static char[,] tahta = new char[boyut, boyut];
        static bool[,] mayinlar = new bool[boyut, boyut];
        static bool[,] acilanHucreseler = new bool[boyut, boyut];

        static void Main()
        {
            TahtaOlustur();
            MayinlariYerleştir();
            Oyun();
        }

        static void TahtaOlustur()
        {
            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    tahta[i, j] = '-';
                    acilanHucreseler[i, j] = false;
                }
            }
        }

        static void MayinlariYerleştir()
        {
            Random rnd = new Random();
            int yerlestirilenMayin = 0;

            while (yerlestirilenMayin < mayinSayisi)
            {
                int x = rnd.Next(0, boyut);
                int y = rnd.Next(0, boyut);

                if (!mayinlar[x, y])
                {
                    mayinlar[x, y] = true;
                    yerlestirilenMayin++;
                }
            }
        }

        static void TahtayiYazdir()
        {
            Console.Clear();
            Console.Write("     "); // Sütun başlıkları
            for (int i = 1; i <= boyut; i++)
            {
                Console.Write(i.ToString().PadLeft(3));
            }
            Console.WriteLine();

            for (int i = 0; i < boyut; i++)
            {
                Console.Write((i + 1).ToString().PadLeft(3) + " "); // Satır başlıkları
                for (int j = 0; j < boyut; j++)
                {
                    Console.Write(tahta[i, j].ToString().PadLeft(3));
                }
                Console.WriteLine();
            }
        }

        static void Oyun()
        {
            bool devam = true;

            while (devam)
            {
                TahtayiYazdir();

                int x = -1, y = -1;

                // Satır girişini kontrol et
                while (true)
                {
                    Console.Write($"Satır (1-{boyut}): ");
                    if (int.TryParse(Console.ReadLine(), out x) && x >= 1 && x <= boyut)
                    {
                        x--; // Kullanıcı girişi 1-20 aralığında olduğu için 0-19’a uyarlanıyor
                        break;
                    }
                    else
                        Console.WriteLine("Geçersiz giriş! Lütfen belirtilen aralıkta bir tamsayı girin.");
                }

                // Sütun girişini kontrol et
                while (true)
                {
                    Console.Write($"Sütun (1-{boyut}): ");
                    if (int.TryParse(Console.ReadLine(), out y) && y >= 1 && y <= boyut)
                    {
                        y--; // Kullanıcı girişi 1-20 aralığında olduğu için 0-19’a uyarlanıyor
                        break;
                    }
                    else
                        Console.WriteLine("Geçersiz giriş! Lütfen belirtilen aralıkta bir tamsayı girin.");
                }

                // İşlem yapma
                if (mayinlar[x, y])
                {
                    Console.Clear();
                    Console.WriteLine("BOOM! Mayına bastınız! Oyun bitti.");
                    Console.ReadLine();
                    devam = false;
                }
                else
                {
                    if (SayilarHesapla(x, y) == '0')
                    {
                        FloodFill(x, y);
                    }
                    else
                    {
                        tahta[x, y] = SayilarHesapla(x, y);
                        acilanHucreseler[x, y] = true;
                    }

                    if (TumHucreselerAcildiMi())
                    {
                        Console.Clear();
                        Console.WriteLine("Tebrikler! Tüm mayınlardan kaçındınız!");
                        Console.ReadLine();
                        devam = false;
                    }
                }
            }
        }

        // Flood Fill algoritması ile çevreyi açma
        static void FloodFill(int x, int y)
        {
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { x, y });

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                int currentX = current[0];
                int currentY = current[1];

                // Eğer hücre zaten açılmışsa, devam et
                if (acilanHucreseler[currentX, currentY])
                    continue;

                acilanHucreseler[currentX, currentY] = true;
                tahta[currentX, currentY] = SayilarHesapla(currentX, currentY);

                // Eğer bu hücre etrafında mayın yoksa, çevresini açmak için kuyruğa ekle
                if (tahta[currentX, currentY] == '0')
                {
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int yeniX = currentX + i;
                            int yeniY = currentY + j;

                            // Sınırları kontrol et ve hücreyi açılmamışsa kuyruğa ekle
                            if (yeniX >= 0 && yeniX < boyut && yeniY >= 0 && yeniY < boyut && !acilanHucreseler[yeniX, yeniY])
                            {
                                queue.Enqueue(new int[] { yeniX, yeniY });
                            }
                        }
                    }
                }
            }
        }

        static char SayilarHesapla(int x, int y)
        {
            int sayi = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int yeniX = x + i;
                    int yeniY = y + j;

                    if (yeniX >= 0 && yeniX < boyut && yeniY >= 0 && yeniY < boyut && mayinlar[yeniX, yeniY])
                    {
                        sayi++;
                    }
                }
            }

            return char.Parse(sayi.ToString());
        }

        static bool TumHucreselerAcildiMi()
        {
            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    if (!acilanHucreseler[i, j] && !mayinlar[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

