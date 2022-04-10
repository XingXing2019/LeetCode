// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string MinimizeResult(string expression)
{
    var plus = expression.IndexOf('+');
    var sum = int.MaxValue;
    var res = "";
    var num1 = expression.Substring(0, plus);
    var num2 = expression.Substring(plus + 1);
    for (int i = 0; i < num1.Length; i++)
    {
        for (int j = 0; j < num2.Length; j++)
        {
            var left = num1.Substring(0, i) + '(' + num1.Substring(i);
            var right = num2.Substring(0, j + 1) + ')' + num2.Substring(j + 1);
            var temp = Calculate(left + '+' + right);
            if (temp < sum)
            {
                sum = temp;
                res = left + '+' + right;
            }
        }
    }
    return res;
}

int Calculate(string expression)
{
    var left = expression.IndexOf('(');
    var right = expression.IndexOf(')');
    var plus = expression.IndexOf('+');
    var num1 = left == 0 ? 1 : int.Parse(expression.Substring(0, left));
    var num2 = int.Parse(expression.Substring(left + 1, plus - left - 1));
    var num3 = int.Parse(expression.Substring(plus + 1, right - plus - 1));
    var num4 = right == expression.Length - 1 ? 1 : int.Parse(expression.Substring(right + 1));
    return num1 * (num2 + num3) * num4;
}