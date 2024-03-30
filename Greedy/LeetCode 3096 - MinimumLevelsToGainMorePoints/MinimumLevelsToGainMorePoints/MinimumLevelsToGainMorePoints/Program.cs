int MinimumLevels(int[] possible)
{
    int front = 0, back = 0;
    int[] frontOnes = new int[possible.Length], backOnes = new int[possible.Length];
    for (int i = 0; i < possible.Length; i++)
    {
        front += possible[i] == 1 ? 1 : 0;
        frontOnes[i] = front;
        backOnes[^(i + 1)] = back;
        back += possible[^(i + 1)] == 1 ? 1 : 0;
    }
    for (int i = 0; i < possible.Length - 1; i++)
    {
        var scoreD = frontOnes[i] - (i + 1 - frontOnes[i]);
        var scoreB = backOnes[i] - (possible.Length - i - 1 - backOnes[i]);
        if (scoreD > scoreB)
            return i + 1;
    }
    return -1;
}