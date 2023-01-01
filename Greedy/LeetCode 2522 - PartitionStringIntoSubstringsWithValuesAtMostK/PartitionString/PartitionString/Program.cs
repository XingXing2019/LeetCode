var s = "165462";
var k = 60;
Console.WriteLine(MinimumPartition(s, k));

int MinimumPartition(string s, int k)
{
    long num = 0;
    int res = 0, digit = 0;
    foreach (var l in s)
    {
        digit = l - '0';
        num = num * 10 + digit;
        if (num > k)
        {
            res++;
            num = digit;
        }
        if (num > k)
            return -1;
    }
    return num > k ? -1 : res + 1;
}