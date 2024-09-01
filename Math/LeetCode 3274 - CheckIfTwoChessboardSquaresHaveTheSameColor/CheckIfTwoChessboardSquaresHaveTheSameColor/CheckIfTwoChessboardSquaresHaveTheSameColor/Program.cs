bool CheckTwoChessboards(string coordinate1, string coordinate2)
{
    return Math.Abs(coordinate1[0] - coordinate2[0]) % 2 == Math.Abs(coordinate1[1] - coordinate2[1]) % 2;
}