using System;

namespace ReadNCharactersGivenRead4
{
    class Program
    {
        int Read4(char[] buf4)
        {
            return 0;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int Read(char[] buf, int n)
        {
            if (n == 0) return 0;
            char[] temp = new char[4];
            int count = 0;
            while (count < n)
            {
                int cur = Read4(temp);
                for (int i = 0; i < cur && count < n; i++)
                    buf[count++] = temp[i];
                if (cur < 4) break;
            }
            return count;
        }
    }
}
