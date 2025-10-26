using System.Text;

string MaxSumOfSquares(int num, int sum)
{
    var res = new StringBuilder();
    for (int i = 0; i < num; i++)
    {
        var digit = Math.Min(9, Math.Max(0, sum));
        res.Append(digit);
        sum -= digit;
    }
    return sum == 0 ? res.ToString() : "";
}