int[][] mat = new[]
{
    new[] { 1, 2, 1, 2 },
    new[] { 5, 5, 5, 5 },
    new[] { 6, 3, 6, 3 },
};
var k = 2;
Console.WriteLine(AreSimilar(mat, k));

bool AreSimilar(int[][] mat, int k)
{
    k %= mat[0].Length;
    for (int i = 0; i < mat.Length; i++)
    {
        var temp = mat[i][k..].Concat(mat[i][..k]).ToArray();
        for (int j = 0; j < mat[i].Length; j++)
        {
            if (mat[i][j] == temp[j]) continue;
            return false;
        }
    }
    return true;
}