static int CountIncreasing(int[] arr)
{
    int len = 1, res = 0;
    for (int i = 1; i < arr.Length; i++)
    {
        if (arr[i - 1] <= arr[i]) len++;
        else if (len > 1)
        {
            res++;
            len = 1;
        }
        else len = 1;
    }
    if (len > 1) res++;
    return res;
}

int n = Convert.ToInt32(Console.ReadLine());
int[] a = new int[n];
for (int i = 0; i < n; i++)
{
    a[i] = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine(CountIncreasing(a));