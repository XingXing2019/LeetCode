int TripletCount(int[] a, int[] b, int[] c)
{
    var res = 0;
    foreach (var n1 in a)
    {
        foreach (var n2 in b)
        {
            foreach (var n3 in c)
            {
                var num = n1 ^ n2 ^ n3;
                if (countSetBits(num) % 2 != 0) continue;
                res++;
            }
        }
    }
    return res;
}

int countSetBits(int num)
{
    var res = 0;
    while (num != 0)
    {
        res += (num & 1);
        num >>= 1;
    }
    return res;
}