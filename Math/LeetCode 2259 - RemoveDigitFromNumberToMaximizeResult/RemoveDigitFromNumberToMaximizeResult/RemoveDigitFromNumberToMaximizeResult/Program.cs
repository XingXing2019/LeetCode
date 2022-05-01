// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string RemoveDigit(string number, char digit)
{
    var res = new string('0', number.Length - 1);
    for (int i = 0; i < number.Length; i++)
    {
        if (number[i] != digit) continue;
        var num = number.Substring(0, i) + number.Substring(i + 1);
        if (Compare(num, res))
            res = num;
    }
    return res;
}

bool Compare(string num1, string num2)
{
    for (int i = 0; i < num1.Length; i++)
    {
        if (num1[i] > num2[i])
            return true;
        if (num1[i] < num2[i])
            return false;
    }
    return true;
}