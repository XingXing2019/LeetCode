int TotalNumbers(int[] digits)
{
    var set = new HashSet<int>();
    for (int i = 0; i < digits.Length; i++)
    {
        for (int j = 0; j < digits.Length; j++)
        {
            if (i == j) continue;
            for (int k = 0; k < digits.Length; k++)
            {
                if (j == k) continue;
                var num = digits[i] * 100 + digits[j] * 10 + digits[k];
                set.Add(num);
            }
        }
    }
    return set.Count;
}