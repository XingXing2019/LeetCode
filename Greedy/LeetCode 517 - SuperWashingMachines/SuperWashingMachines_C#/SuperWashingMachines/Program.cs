// See https://aka.ms/new-console-template for more information
int[] machines = { 1, 0, 5 };
Console.WriteLine(FindMinMoves(machines));

int FindMinMoves(int[] machines)
{
    var sum = machines.Sum();
    if (sum % machines.Length != 0) return -1;
    var target = sum / machines.Length;
    var dp = new int[machines.Length];
    var res = 0;
    for (int i = 0; i < machines.Length - 1; i++)
    {
        if (machines[i] == target) continue;
        if (machines[i] > target)
        {
            dp[i] += machines[i] - target;
            machines[i + 1] += machines[i] - target;
            res = Math.Max(res, dp[i]);
        }
        else
        {
            dp[i + 1] = target - machines[i];
            machines[i + 1] -= target - machines[i];
            res = Math.Max(res, dp[i + 1]);
        }
    }
    return res;
}