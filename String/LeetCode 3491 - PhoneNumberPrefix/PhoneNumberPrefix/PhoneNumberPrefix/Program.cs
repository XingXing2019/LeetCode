bool PhonePrefix(string[] numbers)
{
    for (int i = 0; i < numbers.Length; i++)
    {
        for (int j = 0; j < numbers.Length; j++)
        {
            if (i == j) continue;
            if (numbers[j].StartsWith(numbers[i])) return false;
        }
    }
    return true;
}