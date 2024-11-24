var s = "abab";
var t = "baba";
int[] nextCost = { 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
int[] previousCost = { 1, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
Console.WriteLine(ShiftDistance(s, t, nextCost, previousCost));

long ShiftDistance(string s, string t, int[] nextCost, int[] previousCost)
{
    var next = new long[26];
    var prev = new long[26];
    for (int i = 0; i < 26; i++)
    {
        next[i] = i == 0 ? nextCost[i] : nextCost[i] + next[i - 1];
        prev[i] = i == 0 ? previousCost[i] : previousCost[i] + prev[i - 1];
    }
    var res = 0L;
    for (int i = 0; i < s.Length; i++)
    {
        if (t[i] == s[i]) continue;
        int ls = s[i] - 'a', lt = t[i] - 'a';
        if (t[i] > s[i])
        {
            var costNext = next[lt - 1] - (ls == 0 ? 0 : next[ls - 1]);
            var costPrev = prev[^1] - prev[lt] + prev[ls];
            res += Math.Min(costNext, costPrev);
        }
        else
        {
            var costNext = next[^1] - next[ls - 1] + (lt == 0 ? 0 : next[lt - 1]);
            var costPrev = prev[ls] - prev[lt];
            res += Math.Min(costNext, costPrev);
        }
    }
    return res;
}