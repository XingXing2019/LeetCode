int[] FindDegrees(int[][] matrix)
{
    var res = new int[matrix.Length];
    for (int i = 0; i < matrix.Length; i++)
    {
        for (int j = 0; j < matrix[i].Length; j++)
        {
            if (matrix[i][j] == 0) continue;
            res[i]++;
        }
    }
    return res;
}