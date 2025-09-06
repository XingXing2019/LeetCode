long MinOperations(int[][] queries)
{
    var res = 0L;
    foreach (var query in queries)
    {
        var need = Count(query[1]) - Count(query[0] - 1);
        res += (need + 1) / 2;
    }
    return res;
}

long Count(int num)
{
    if (num < 4) return num;
    var res = 3L;
    for (int i = 1; i <= 4; i++)
    {
        var k = (num - i) / 4;
        res += k + Count(k);
    }
    return res;
}