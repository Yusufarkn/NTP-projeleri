using System;


namespace NTPDers1._2
{
    class Program
    {
        static void Main(string[] args)
        {
           
            
                Console.Write("Matrislerin boyutunu giriniz: ");
                int n = int.Parse(Console.ReadLine());

                // İlk matrisi oluşturma
                int[,] matrisA = new int[n, n];
                Console.WriteLine("Birinci matrisi girin:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write($"A[{i + 1},{j + 1}] = ");// +1 ler 0,0 dan başlamak yerine 1,1 den başlamak için
                        matrisA[i, j] = int.Parse(Console.ReadLine());
                    }
                }

                // İkinci matrisi oluşturma
                int[,] matrisB = new int[n, n];
                Console.WriteLine("İkinci matrisi girin:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write($"B[{i + 1},{j + 1}] = ");
                        matrisB[i, j] = int.Parse(Console.ReadLine());
                    }
                }

                // Matris çarpımını gerçekleştirme
                int[,] matrisC = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrisC[i, j] = 0;  // Her elemana başta 0 değeri atama kısmıı
                        for (int k = 0; k < n; k++)
                        {
                            matrisC[i, j] += matrisA[i, k] * matrisB[k, j];
                        }
                    }
                }

                // Sonucu ekrana yazdırma
                Console.WriteLine("Matrislerin çarpım sonucu (3. matris):");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(matrisC[i, j] + "\t");
                    }
                    Console.WriteLine();
                }

                Console.ReadLine();
            }
        }
    }
    

