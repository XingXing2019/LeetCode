int[] books = { 8, 5, 2, 7, 9 };
Console.WriteLine(MaximumBooks(books));

long MaximumBooks(int[] books)
{
    var stack = new Stack<int>();
    var indexes = new int[books.Length];
    for (int i = 0; i < books.Length; i++)
    {
        while (stack.Count != 0 && books[stack.Peek()] - stack.Peek() >= books[i] - i)
            stack.Pop();
        indexes[i] = stack.Count == 0 ? -1 : stack.Peek();
        stack.Push(i);
    }
    var dp = new long[books.Length];
    dp[0] = books[0];
    long res = dp[0];
    for (int i = 1; i < dp.Length; i++)
    {
        var index = indexes[i];
        if (index != -1)
            dp[i] = dp[index] + (long)(books[i] + books[i] - (i - index - 1)) * (i - index) / 2;
        else
        {
            var count = Math.Min(i + 1, books[i]);
            dp[i] = (long)(books[i] + books[i] - count + 1) * count / 2;
        }
        res = Math.Max(res, dp[i]);
    }
    return res;
}