double eps = Convert.ToDouble(Console.ReadLine());
Console.WriteLine(Pi(eps));

static double Pi(double eps = 0)
{
    double pi = Math.PI;
    double x1 = 1 / 5.0, x2 = 1 / 239.0;
    int k = 0;
    double res = 16 * x1 - 4 * x2;
    while (Math.Abs(res - pi) > eps)
    {
        x1 *= -1 / 25.0;
        x2 *= -1 / 239 / 239;
        k++;
        res += (16 * x1 - 4 * x2) / (2 * k + 1);
    }
    return res;
}
