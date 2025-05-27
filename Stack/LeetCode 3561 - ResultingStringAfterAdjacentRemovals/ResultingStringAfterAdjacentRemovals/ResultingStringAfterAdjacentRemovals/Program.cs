var s = "zadb";
Console.WriteLine(ResultingString(s));

string ResultingString(string s)
{
    var stack = new Stack<char>();
    foreach (var l in s)
    {
        if (stack.Count != 0 && (Math.Abs(stack.Peek() - l) == 1 || Math.Abs(stack.Peek() - l) == 25))
            stack.Pop();
        else
            stack.Push(l);
    }
    return string.Join("", stack.Reverse().ToArray());
}