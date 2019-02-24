using System;

namespace CodeSignalRotateImage
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] a = new int[3][];

            a[0] = new int[3] { 1, 2, 3 };
            a[1] = new int[3] { 4, 5, 6 };
            a[2] = new int[3] { 7, 8, 9 };

        int n = a.GetLength(0);

            int[][] result = new int[n][];
            for (int k = 0; k < n; k++)
            {
                result[k] = new int[n];
            }

            int newR;
            int newC;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j <= n/2)
                    {
                        newC = (n - i) - 1
                    }
                    else
                    {
                        newC = ()
                    }
                    else if ()
                    result[j][(n - i) - 1] = a[i][j];
                }
            }



            int b = 5;
            Console.ReadLine();
        }
    }
}
