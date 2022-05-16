using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace MaximumWhiteTiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] tiles = new[]
            {
                new[] { 1, 5 },
                new[] { 10, 11 },
                new[] { 12, 18 },
                new[] { 20, 25 },
                new[] { 30, 32 },
            };
            var carpetLen = 10;
            Console.WriteLine(MaximumWhiteTiles(tiles, carpetLen));
        }

        public static int MaximumWhiteTiles(int[][] tiles, int carpetLen)
        {
            tiles = tiles.OrderBy(x => x[0]).ToArray();
            var prefix = new int[tiles.Length];
            for (int i = 0; i < tiles.Length; i++)
                prefix[i] = i == 0 ? tiles[i][1] - tiles[i][0] + 1 : tiles[i][1] - tiles[i][0] + 1 + prefix[i - 1];
            var res = 0;
            for (int i = 0; i < tiles.Length; i++)
            {
                var index = BinarySearch(tiles, i, tiles[i][0] + carpetLen - 1);
                var len = prefix[index] - (i == 0 ? 0 : prefix[i - 1]);
                var last = Math.Min(tiles[index][1], tiles[i][0] + carpetLen - 1) - tiles[index][0] + 1;
                len = len - (tiles[index][1] - tiles[index][0] + 1) + Math.Max(0, last);
                res = Math.Max(res, len);
            }
            return res;
        }

        public static int BinarySearch(int[][] tile, int start, int target)
        {
            int li = start, hi = tile.Length - 1;
            while (li < hi)
            {
                var mid = li + (hi - li) / 2;
                if (tile[mid][0] <= target && target <= tile[mid][1])
                    return mid;
                if (tile[mid][1] < target)
                    li = mid + 1;
                else if (tile[mid][0] > target)
                    hi = mid;
            }
            return li;
        }
    }
}
