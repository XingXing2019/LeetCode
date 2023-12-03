int[] coins = { 1, 1, 1 };
var target = 20;
Console.WriteLine(MinimumAddedCoins(coins, target));

int MinimumAddedCoins(int[] coins, int target)
{
    Array.Sort(coins);
    int res = 0, maxReach = 0, index = 0;
    while (index < coins.Length)
    {
        if (maxReach + 1 >= coins[index])
        {
            maxReach += coins[index];
            index++;
        }
        else
        {
            res++;
            maxReach = maxReach * 2 + 1;
        }
    }
    while (maxReach < target)
    {
        maxReach = maxReach * 2 + 1;
        res++;
    }
    return res;
}