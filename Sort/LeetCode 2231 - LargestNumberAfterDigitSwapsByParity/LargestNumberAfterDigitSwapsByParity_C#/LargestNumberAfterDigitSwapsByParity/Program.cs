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

int LargestInteger_Heap(int num)
{
    int copy = num, res = 0, pow = 1;
    var odd = new PriorityQueue<int, int>();
    var even = new PriorityQueue<int, int>();
    while (copy != 0)
    {
        var mod = copy % 10;
        if (copy % 10 % 2 == 0)
            even.Enqueue(mod, -mod);
        else
            odd.Enqueue(mod, -mod);
        copy /= 10;
        if (copy != 0)
            pow *= 10;
    }
    while (num != 0)
    {
        var mod = num / pow % 10;
        if (mod % 2 == 0)
            res += even.Dequeue() * pow;
        else
            res += odd.Dequeue() * pow;
        num %= pow;
        pow /= 10;
    }
    return res;
}