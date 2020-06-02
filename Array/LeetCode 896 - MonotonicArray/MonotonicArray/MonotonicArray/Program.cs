using System;

namespace MonotonicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = {1, 2, 3, 4};
            Console.WriteLine(IsMonotonic(A));
        }
        static bool IsMonotonic(int[] A)
        {
            if (A.Length == 1)
                return true;
            const string increase = "increase";
            const string decrease = "decrease";
            const string start = "start";
            string state = start;
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] == A[i - 1])
                    continue;
                switch (state)
                {
                    case start:
                        state = A[i] > A[i - 1] ? increase : decrease;
                        break;
                    case increase:
                        if (A[i] < A[i - 1])
                            return false;
                        break;
                    case decrease:
                        if (A[i] > A[i - 1])
                            return false;
                        break;
                }
            }
            return true;
        }
    }
}
