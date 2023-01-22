int[][] SortTheStudents(int[][] score, int k)
{
    return score.OrderByDescending(x => x[k]).ToArray();
}