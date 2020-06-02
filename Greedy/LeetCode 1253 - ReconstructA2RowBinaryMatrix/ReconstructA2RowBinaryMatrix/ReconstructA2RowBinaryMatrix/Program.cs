using System;
using System.Collections.Generic;
using System.Linq;

namespace ReconstructA2RowBinaryMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int upper = 9;
            int lower = 2;
            int[] colsum = { 0, 1, 2, 0, 0, 0, 0, 0, 2, 1, 2, 1, 2 };
            Console.WriteLine(ReconstructMatrix(upper, lower, colsum));
        }
        static IList<IList<int>> ReconstructMatrix(int upper, int lower, int[] colsum)
        {               
            var res = new int[2][];
            res[0] = new int[colsum.Length];
            res[1] = new int[colsum.Length];           
            for (int i = 0; i < colsum.Length; i++)
            {                
                if( colsum[i] == 2)
                {
                    res[0][i] = 1;
                    res[1][i] = 1;
                    upper--;
                    lower--;
                }
                if(upper < 0 || lower < 0)
                    return new List<IList<int>>();
            }
            for (int i = 0; i < colsum.Length; i++)
            {
                if (colsum[i] == 1)
                {
                    if (upper != 0)
                    {
                        res[0][i] = 1;
                        upper--;
                    }
                    else
                    {
                        res[1][i] = 1;
                        lower--;
                    }
                    if (upper < 0 || lower < 0)
                        return new List<IList<int>>();
                }
            }
            if (upper != 0 || lower != 0)
                return new List<IList<int>>();
            return res;
        }
    }
}
