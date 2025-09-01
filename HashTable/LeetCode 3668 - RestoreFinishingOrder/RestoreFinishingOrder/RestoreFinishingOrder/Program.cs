int[] RecoverOrder(int[] order, int[] friends)
{
    var set = new HashSet<int>(friends);
    var res = new int[friends.Length];
    var index = 0;
    foreach (var o in order)
    {
        if (!set.Contains(o)) continue;
        res[index++] = o;
    }
    return res;
}