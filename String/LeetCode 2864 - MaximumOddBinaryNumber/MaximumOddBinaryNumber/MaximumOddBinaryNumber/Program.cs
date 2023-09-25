string MaximumOddBinaryNumber(string s)
{
    int zeros = s.Count(x => x == '0'), one = s.Count(x => x == '1');
    return $"{new string('1', one - 1)}{new string('0', zeros)}1";
}