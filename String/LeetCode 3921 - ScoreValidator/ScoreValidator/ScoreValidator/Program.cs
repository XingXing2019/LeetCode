int[] ScoreValidator(string[] events)
{
    var res = new int[2];
    foreach (var e in events)
    {
        if (res[1] == 10) return res;
        if (int.TryParse(e, out var score))
            res[0] += score;
        else if (e == "W")
            res[1]++;
        else
            res[0]++;
    }
    return res;
}