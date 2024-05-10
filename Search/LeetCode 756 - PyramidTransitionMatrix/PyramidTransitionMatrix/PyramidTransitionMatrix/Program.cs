bool PyramidTransition(string bottom, IList<string> allowed)
{
    var matrix = new int[bottom.Length][];
    for (int i = 0; i < matrix.Length; i++)
        matrix[i] = new int[bottom.Length];
    for (int i = 0; i < bottom.Length; i++)
        matrix[^1][i] = bottom[i] - 'A';
    var candidates = new bool[6][][];
    for (int i = 0; i < candidates.Length; i++)
    {
        candidates[i] = new bool[6][];
        for (int j = 0; j < candidates.Length; j++)
            candidates[i][j] = new bool[6];
    }
    foreach (var word in allowed)
        candidates[word[0] - 'A'][word[1] - 'A'][word[2] - 'A'] = true;
    return DFS(matrix, matrix.Length - 1, 0, candidates);
}

bool DFS(int[][] matrix, int level, int index, bool[][][] candidates)
{
    if (level == 0) return true;
    if (level == index)
        return DFS(matrix, level - 1, 0, candidates);
    var first = matrix[level][index];
    var second = matrix[level][index + 1];
    for (int i = 0; i < 6; i++)
    {
        if (!candidates[first][second][i]) continue;
        matrix[level - 1][index] = i;
        if (DFS(matrix, level, index + 1, candidates))
            return true;
    }
    return false;
}