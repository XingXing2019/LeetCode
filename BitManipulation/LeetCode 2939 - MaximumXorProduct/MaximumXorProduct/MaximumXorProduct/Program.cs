using System.Reflection;

long a = 1, b = 6;
var n = 3;
Console.WriteLine(MaximumXorProduct(a, b, n));

int MaximumXorProduct(long a, long b, int n)
{
    long x = 0, mask = 1L << (n - 1), mod = 1_000_000_000 + 7;
    for (int i = 0; i < n; i++)
    {
        if ((a & mask) == (b & mask) && (a & mask) == 0)
            x |= mask;
        else if ((a & mask) != (b & mask))
        {
            long valA = a ^ x, valB = b ^ x;
            if (valA < valB && (valA & mask) == 0 || valA >= valB && (valB & mask) == 0)
                x |= mask;
        }
        mask >>= 1;
    }
    return (int)((a ^ x) % mod * ((b ^ x) % mod) % mod);
}