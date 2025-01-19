long MinCost(int[] arr, int[] brr, long k)
{
    var sortedA = arr.OrderBy(x => x).ToArray();
    var sortedB = brr.OrderBy(x => x).ToArray();
    long res = 0L, diff = 0L;
    for (int i = 0; i < sortedA.Length; i++)
    {
        res += Math.Abs(sortedA[i] - sortedB[i]);
        diff += Math.Abs(arr[i] - brr[i]);
    }
    return res == diff ? res : Math.Min(res + k, diff);
}