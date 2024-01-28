int n = 3, m = 99;
Console.WriteLine(FlowerGame(n, m));

long FlowerGame(int n, int m)
{
    long oddN = n % 2 == 0 ? n / 2 : n / 2 + 1, evenN = n / 2;
    long oddM = m % 2 == 0 ? m / 2 : m / 2 + 1, evenM = m / 2;
    return oddN * evenM + evenN * oddM;
}