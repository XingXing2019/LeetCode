public class matrix3D
{
    int[] freq;
    int[][][] matrix;
    public matrix3D(int n)
    {
        freq = new int[n];
        matrix = new int[n][][];
        for (int i = 0; i < n; i++)
        {
            matrix[i] = new int[n][];
            for (int j = 0; j < n; j++)
            {
                matrix[i][j] = new int[n];
            }
        }
    }

    public void SetCell(int x, int y, int z)
    {
        if (matrix[x][y][z] == 1)
            return;
        freq[x]++;
        matrix[x][y][z] = 1;
    }

    public void UnsetCell(int x, int y, int z)
    {
        if (matrix[x][y][z] == 0)
            return;
        freq[x]--;
        matrix[x][y][z] = 0;
    }

    public int LargestMatrix()
    {
        var max = freq.Max();
        for (int i = freq.Length - 1; i >= 0; i--)
        {
            if (freq[i] == max)
                return i;
        }
        return -1;
    }
}