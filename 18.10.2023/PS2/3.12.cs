Console.WriteLine(LeftRectangles(1, 2, 10000));
Console.WriteLine(RightRectangles(1, 2, 10000));
Console.WriteLine(Trapezoid(1, 2, 10000));
Console.WriteLine(Simpson(1, 2, 1000000));
Console.WriteLine(MonteCarlo(1, 2, 50000));


static double F(double x) // Интегрируемая фунция в отдельном методе
{
    return -1 * Math.Tan(Math.Cos(2 * x));
}


static double LeftRectangles(double left, double right, double segmentCount) // Левые прямоугольники
{
    double segmentLength = 1 / segmentCount;
    double res = 0;
    for (double i = left; i < right; i += segmentLength)
    {
        res += F(i);
    }
    return res * segmentLength;
}

static double RightRectangles(double left, double right, double segmentCount) // Правые прямоугольники
{
    double segmentLength = 1 / segmentCount;
    double res = 0;
    for (double i = left; i <= right - segmentLength; i += segmentLength)
    {
        res += F(i + segmentLength);
    }
    return res * segmentLength;
}

static double Trapezoid(double left, double right, double segmentCount) // Метод трапеций
{
    double segmentLength = 1 / segmentCount;
    double res = 0;
    for (double i = left; i <= right - segmentLength; i += segmentLength)
    {
        res += (F(i) + F(i + segmentLength)) / 2 * segmentLength;
    }
    return res;
}

static double Simpson(double left, double right, double segmentCount) // Метод Симпсона
{
    double res = 0;
    double segmentLength = 0;
    if (segmentCount % 2 == 1) segmentCount++; // По условию кол-во сегментов чётное
    segmentLength = 1 / segmentCount;
    for (double i = left; i < right; i += segmentLength)
    {
        res += segmentLength / 6 * (F(i) + 4 * F((2 * i + segmentLength) / 2) + F(i + segmentLength));
    }
    return res;
}


static double MonteCarlo(double left, double right, double segmentCount) // Метод Монте-Карло
{
    double segmentXLength = 1 / segmentCount;
    double segmentYLength = 1.6 / segmentCount;
    double innerCount = 0, count = 0;
    for (double x = left; x <= right; x += segmentXLength)
    {
        double f = F(x);
        for (double y = 0; y <= 1.6; y += segmentYLength)
        {
            if (y >= 0 && y <= f) innerCount++;
            count++;
        }
    }
    return innerCount / count * 1.6; // Умножаем на 1.6 из-за площади рассматриваемой области
}
