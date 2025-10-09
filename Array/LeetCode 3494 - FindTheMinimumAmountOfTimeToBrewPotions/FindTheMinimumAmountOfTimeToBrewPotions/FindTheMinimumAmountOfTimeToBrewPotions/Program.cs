long MinTime(int[] skill, int[] mana)
{
    var res = new long[skill.Length + 1];
    for (int i = 0; i < res.Length; i++)
        res[i] = i == 0 ? 0 : res[i - 1] + skill[i - 1] * mana[0];
    for (int i = 1; i < mana.Length; i++)
    {
        var temp = new long[skill.Length + 1];
        for (int j = 0; j < temp.Length; j++)
            temp[j] = j == 0 ? 0 : temp[j - 1] + skill[j - 1] * mana[i];
        var max = long.MinValue;
        for (int j = 0; j < temp.Length - 1; j++)
            max = Math.Max(max, res[j + 1] - temp[j]);
        for (int j = 0; j < temp.Length; j++)
            temp[j] += max;
        res = temp;
    }
    return res[^1];
}