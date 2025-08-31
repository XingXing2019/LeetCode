int GetLeastFrequentDigit(int n)
{
    var freq = new int[10];
    while (n != 0)
    {
        freq[n % 10]++;
        n /= 10;
    }
    int min = int.MaxValue, res = -1;
    for (int i = 0; i < freq.Length; i++)
    {
        if (freq[i] == 0) continue;
        if (freq[i] < min)
        {
            res = i;
            min = freq[i];
        }
    }
    return res;
}