// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public int LargestInteger(int num)
{
    var odd = new List<int>();
    var even = new List<int>();
    var str = num.ToString();
    while (num != 0)
    {
        if (num % 10 % 2 == 0)
            even.Add(num % 10);
        else
            odd.Add(num % 10);
        num /= 10;
    }
    even = even.OrderByDescending(x => x).ToList();
    odd = odd.OrderByDescending(x => x).ToList();
    int res = 0, p1 = 0, p2 = 0;
    for (int i = 0; i < str.Length; i++)
    {
        if ((str[i] - '0') % 2 == 0)
            res = res * 10 + even[p1++];
        else
            res = res * 10 + odd[p2++];
    }
    return res;
}