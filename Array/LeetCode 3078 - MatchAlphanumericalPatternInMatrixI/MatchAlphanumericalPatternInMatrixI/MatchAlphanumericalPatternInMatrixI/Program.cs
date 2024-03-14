int[] FindPattern(int[][] board, string[] pattern)
{
    for (int r = 0; r < board.Length; r++)
    {
        for (int c = 0; c < board[0].Length; c++)
        {
            if (!IsMatch(board, pattern, r, c)) continue;
            return new[] { r, c };
        }
    }
    return new[] { -1, -1 };
}

bool IsMatch(int[][] board, string[] pattern, int r, int c)
{
    if (board.Length - r < pattern.Length || board[0].Length - c < pattern[0].Length)
        return false;
    var map = new Dictionary<char, int>();
    var seen = new HashSet<int>();
    for (int i = 0; i < pattern.Length; i++)
    {
        for (int j = 0; j < pattern[0].Length; j++)
        {
            var digit = board[r + i][c + j];
            var letter = pattern[i][j];
            if (char.IsDigit(letter) && digit != letter - '0')
                return false;
            if (!char.IsDigit(letter))
            {
                if (map.ContainsKey(letter) && map[letter] != digit || !map.ContainsKey(letter) && !seen.Add(digit))
                    return false;
                map[pattern[i][j]] = digit;
            }
        }
    }
    return true;
}