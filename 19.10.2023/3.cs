static void PrintMatrix(int[,] a)
{
    int m = a.GetLength(0);
    int n = a.GetLength(1);
    Console.WriteLine();
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            Console.Write($"{a[i, j],5}");
        }
        Console.WriteLine();
    }
}


static void ChangeMAxAndMin(int[,] a)
{
    int m = a.GetLength(0);
    int n = a.GetLength(1);
    PrintMatrix(a);
    int min = int.MaxValue; int max = int.MinValue;
    int imax = 0, jmax = 0, imin = 0, jmin = 0;
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (min > a[i, j])
            {
                min = a[i, j];
                imin = i;
                jmin = j;
            }
            if (max < a[i, j])
            {
                max = a[i, j];
                imax= i;
                jmax = j;
            }
        }
    }
    (a[imin, jmin], a[imax, jmax]) = (a[imax, jmax], a[imin, jmin]);
    PrintMatrix(a);
}


int m = Convert.ToInt32(Console.ReadLine());
int n = Convert.ToInt32(Console.ReadLine());
int[,] a = new int[m, n];
Random r = new Random();
for (int i = 0; i < m; i++)
{
    for (int j = 0; j < n; j++)
    {
        a[i, j] = r.Next(-1000, 1000);
    }
}

ChangeMAxAndMin(a);