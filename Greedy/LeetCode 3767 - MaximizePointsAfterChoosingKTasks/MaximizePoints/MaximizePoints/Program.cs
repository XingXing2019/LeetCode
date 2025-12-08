long MaxPoints(int[] technique1, int[] technique2, int k)
{
    var res = 0L;
    var diff = new int[technique1.Length];
    for (int i = 0; i < technique1.Length; i++)
    {
        diff[i] = technique2[i] - technique1[i];
        res += technique1[i];
    }
    Array.Sort(diff);
    for (int i = k; i < diff.Length; i++)
        res += Math.Max(0, diff[i]);
    return res;
}