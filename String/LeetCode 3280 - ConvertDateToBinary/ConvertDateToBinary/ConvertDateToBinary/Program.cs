string ConvertDateToBinary(string date)
{
    var parts = date.Split('-');
    for (int i = 0; i < parts.Length; i++)
        parts[i] = ToBinary(parts[i]);
    return string.Join('-', parts);
}

string ToBinary(string str)
{
    var num = int.Parse(str);
    var res = "";
    while (num != 0)
    {
        res = num % 2 + res;
        num /= 2;
    }
    return res;
}