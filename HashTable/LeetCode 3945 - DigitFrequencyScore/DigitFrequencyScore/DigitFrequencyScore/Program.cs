int DigitFrequencyScore(int n)
{
    var freq = new int[10];
    while (n != 0)
    {
        freq[n % 10]++;
        n /= 10;
    }
    var res = 0;
    for (int i = 0; i < freq.Length; i++)
        res += i * freq[i];
    return res;
}