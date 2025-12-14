int[] balance = { 7, 3, 7, -11, 3 };
Console.WriteLine(MinMoves(balance));

long MinMoves(int[] balance)
{
    long res = 0, sum = 0, dis = 1;
    var index = -1;
    for (int i = 0; i < balance.Length; i++)
    {
        if (balance[i] < 0)
            index = i;
        sum += balance[i];
    }
    if (index == -1) return 0;
    if (sum < 0) return -1;
    int li = index - 1 < 0 ? balance.Length - 1 : index - 1, hi = index + 1 >= balance.Length ? 0 : index + 1;
    while (balance[index] < 0 && hi != li)
    {
        res += dis * balance[li] + dis * balance[hi];
        balance[index] += balance[li--] + balance[hi++];
        if (balance[index] > 0) return res - dis * balance[index];
        if (li < 0) li = balance.Length - 1;
        if (hi == balance.Length) hi = 0;
        dis++;
    }
    if (balance[index] < 0)
    {
        res += dis * balance[li];
        balance[index] += balance[li];
    }
    return res - dis * balance[index];
}