using System;

namespace NTPDers1
{
    class Program
    {
        void Main(string[]args)
        {
            int[,] dizi = new int[5, 5];
            int left = 0;
            int right = dizi.GetLength(0) - 1;
            int top = 0;
            int bottom = dizi.GetLength(1) - 1;
            int value = 1;

            while (left <= right && top <= bottom)
            {
                // soldan sağa
                for (int i = left; i <= right; i++)
                {
                    dizi[top, i] = value;
                    value++;
                }
                top++;

                // yukarıdan aşağıya
                for (int i = top; i <= bottom; i++)
                {
                    dizi[i, right] = value;
                    value++;
                }
                right--;

                // sağdan sola
                if (left <= right)
                {
                    for (int i = right; i >= left; i--)
                    {
                        dizi[bottom, i] = value;
                        value++;
                    }
                    bottom--;
                }

                // aşağıdan yukarıya
                if (top <= bottom)
                {
                    for (int i = bottom; i >= top; i--)
                    {
                        dizi[i, left] = value;
                        value++;
                    }
                    left++;
                }
            }

            // Diziyi ekrana yazdırma
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(dizi[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}

