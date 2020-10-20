using System;
using System.Linq;

namespace MaximumFont
{
    interface FontInfo
    {
        public int GetWidth(int fontSize, char ch);
        public int GetHeight(int fontSize);
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MaxFont(string text, int w, int h, int[] fonts, FontInfo fontInfo)
        {
            int li = 0, hi = fonts.Length - 1;
            while (li <= hi)
            {
                int mid = li + (hi - li) / 2;
                var height = fontInfo.GetHeight(fonts[mid]);
                var width = 0;
                foreach (var letter in text)
                    width += fontInfo.GetWidth(fonts[mid], letter);
                if (height <= h && width <= w)
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
            return hi < 0 ? -1 : fonts[hi];
        }
    }
}
