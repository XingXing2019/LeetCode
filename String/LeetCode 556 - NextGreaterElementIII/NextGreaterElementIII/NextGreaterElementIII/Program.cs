using System;
using System.Collections.Generic;

namespace NextGreaterElementIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 12443322;
            Console.WriteLine(NextGreaterElement(n));
        }
        static int NextGreaterElement(int n)
        {
            var list = new List<int>();
            int tem = n;
            while (tem != 0)
            {
                list.Add(tem % 10);
                tem /= 10;
            }
            if (list.Count == 1)
                return -1;
            int index = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                if(list[i] > list[i + 1])
                {
                    index = i;
                    break;
                }
            }
            var partOne = new int[index + 1];
            var partTwo = new int[list.Count - index - 1];
            list.CopyTo(0, partOne, 0, index + 1);
            list.CopyTo(index + 1, partTwo, 0, list.Count - index - 1);
            Array.Sort(partOne);
            for (int i = 0; i < partOne.Length; i++)
            {
                if(partOne[i] > partTwo[0])
                {
                    int num = partOne[i];
                    partOne[i] = partTwo[0];
                    partTwo[0] = num;
                    break;
                }
            }
            string str = "";
            for (int i = partTwo.Length - 1; i >= 0; i--)
                str += partTwo[i];
            for (int i = 0; i < partOne.Length; i++)
                str += partOne[i];
            int res;
            bool isValid = int.TryParse(str, out res);
            if (!isValid || res == n)
                return -1;
            else
                return res;
        }
    }
}
