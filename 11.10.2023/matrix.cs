int n = Convert.ToInt32(Console.ReadLine());
int[,] a = new int[n, n];
//for (int i = 0; i < n; i++)
//{
//    a[i, 0] = 1;
//    a[0, i] = 1;
//    a[n - 1, i] = 1;
//    a[i, n - 1] = 1;
//}
//PrintMatrix(a);

//for (int i = 0; i < n; i++)
//{
//    a[i, i] = 1;
//    a[i, n - i - 1] = 1;
//}
//PrintMatrix(a);

for (int i = 0; i < n; i++)
{
    for (int j = i; j < n - i; j++)
    {
        a[i, j] = 1;
        a[n - i - 1, j] = 1;
    }
}
PrintMatrix(a);

static void PrintMatrix(int[,] matrix)
{
    int n = matrix.Length;
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            Console.Write($"{matrix[i, j],2}");
        }
        Console.WriteLine();
    }
}

/* 
 * Концепция в том, что если мы можем обратиться к конкретному значению,
 * значит, мы сможем и прибавить его к сумме.
 * В случае с 6 заданием, после нахождения суммы надо вычесть значение a[n / 2, n / 2],
 * потому что при сложении диагоналей оно берется дважды.
 */

 