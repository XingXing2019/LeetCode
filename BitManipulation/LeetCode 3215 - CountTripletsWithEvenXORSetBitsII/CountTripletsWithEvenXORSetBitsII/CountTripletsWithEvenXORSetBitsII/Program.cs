int[] a = { 1 };
int[] b = { 2 };
int[] c = { 3 };
Console.WriteLine(TripletCount(a, b, c));

long TripletCount(int[] a, int[] b, int[] c)
{
    long aEven = 0, aOdd = 0;
    long bEven = 0, bOdd = 0;
    long cEven = 0, cOdd = 0;
    long res = 0;
    foreach (var num in a)
    {
        if (IsEven(num)) aEven++;
        else aOdd++;
    }
    foreach (var num in b)
    {
        if (IsEven(num)) bEven++;
        else bOdd++;
    }
    foreach (var num in c)
    {
        if (IsEven(num)) cEven++;
        else cOdd++;
    }
    res += aEven * bEven * cEven;
    res += aEven * bOdd * cOdd;
    res += aOdd * bEven * cOdd;
    res += aOdd * bOdd * cEven;
    return res;
}

bool IsEven(int num)
{
    var res = 0;
    while (num != 0)
    {
        res += num % 2 == 0 ? 0 : 1;
        num >>= 1;
    }
    return res % 2 == 0;
}