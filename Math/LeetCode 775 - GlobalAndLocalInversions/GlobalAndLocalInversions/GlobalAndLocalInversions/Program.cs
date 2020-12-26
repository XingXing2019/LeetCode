using System;

namespace GlobalAndLocalInversions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool IsIdealPermutation(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                if (Math.Abs(A[i] - i) > 1)
                    return false;
            }
            return true;
        }
    }
}
