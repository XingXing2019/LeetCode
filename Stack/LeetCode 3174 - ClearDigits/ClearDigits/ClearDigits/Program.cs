string ClearDigits(string s)
{
    var stack = new Stack<char>();
    foreach (var l in s)
    {
        if (char.IsDigit(l))
            stack.Pop();
        else
            stack.Push(l);
    }
    return string.Join("", stack.Reverse());
}