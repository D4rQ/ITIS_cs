double x = double.Parse(Console.ReadLine());
double a = double.Parse(Console.ReadLine());
double eps = double.Parse(Console.ReadLine());
Console.WriteLine(Pow(x, a, eps));

static double Pow(double x, double a, double eps = 0)
{
    double currentTerm = x, pastTerm = 1;
    int k = 1;
    double res = 0;
    while (Math.Abs(currentTerm - pastTerm) > eps)
    {
        res += currentTerm;
        pastTerm = currentTerm;
        currentTerm *= (a - 1) * Math.Log(x) / k;
        k++;
    }
    System.Console.WriteLine(k);
    return Math.Round(res, 8);
}
