static bool IsSimmetrical(int[] arr)
{
    for (int i = 0; i < arr.Length / 2; i++)
    {
        if (arr[i] != arr[arr.Length - 1 - i]) return false;
    }
    return true;
}

int[] a = new int[] { 1, 2, 3, 4, 5, 4, 3, 2, 1 };
int[] b = new int[] { 1, 2, 3, 4 };
Console.WriteLine(IsSimmetrical(a));
Console.WriteLine(IsSimmetrical(b));