using System.Linq;

namespace LonelyPixelI
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        static int FindLonelyPixel(char[][] picture)
        {
            int res = 0;
            var rowNumber = new int[picture.Length];
            for (int r = 0; r < picture.Length; r++)
            {
                int count = picture[r].Count(x => x == 'B');
                res += count;
                rowNumber[r] = count;
            }
            for (int c = 0; c < picture[0].Length; c++)
            {
                int count = 0, row = -1;
                for (int r = 0; r < picture.Length; r++)
                {
                    count += picture[r][c] == 'B' ? 1 : 0;
                    if (count == 1)
                        row = r;
                }
                res -= count > 1 ? count : 0;
                if (count == 1 && rowNumber[row] > 1)
                    res--;
            }
            return res;
        }
    }
}
