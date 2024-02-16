int[][] ModifiedMatrix(int[][] matrix)
{
    var colMax = new int[matrix[0].Length];
    for (int j = 0; j < matrix[0].Length; j++)
    {
        var max = int.MinValue;
        for (int i = 0; i < matrix.Length; i++)
        {
            max = Math.Max(max, matrix[i][j]);
        }
        colMax[j] = max;
    }
    for (int j = 0; j < matrix[0].Length; j++)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            if (matrix[i][j] != -1) continue;
            matrix[i][j] = colMax[j];
        }   
    }
    return matrix;
}