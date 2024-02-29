// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

class Problem
{
    public int CommonSetBits(int num) => 0;
}

class Solution : Problem
{
    public int FindNumber()
    {
        var res = 0;
        for (int i = 0; i < 30; i++)
        {
            if (CommonSetBits(1 << i) != 1) continue;
            res += 1 << i;
        }
        return res;
    }
}