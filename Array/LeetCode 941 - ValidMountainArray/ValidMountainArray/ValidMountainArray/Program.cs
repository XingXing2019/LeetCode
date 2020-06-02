//创建change记录拐点的个数。创建start，up和down三种状态。创建state代表当前状态，初始值设为start。
//从第二个元素开始遍历数组。当前状态为start时，如果当前元素小于等于其前一元素，则返回false，否则将state转换为up状态。
//当前状态为up时，如果当前元素比其前一元素小，则使change加一，并将状态转换为down。如果当前元素等于其前一元素，则返回false。
//当前状态为down时，如果当前元素比其前一元素大， 则使change加一，并将状态装换为up。如果当前元素等于其前一元素，则返回false。
//最后判断change的次数，如果等于1，则返回true。否则返回false。
using System;

namespace ValidMountainArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool ValidMountainArray(int[] A)
        {
            if (A.Length == 0)
                return false;
            int change = 0;
            const string start = "start";
            const string up = "up";
            const string down = "down";
            string state = start;
            for (int i = 1; i < A.Length; i++)
            {
                switch (state)
                {
                    case start:
                        if (A[i] <= A[i - 1])
                            return false;
                        else
                            state = "up";
                        break;
                    case up:
                        if (A[i] < A[i - 1])
                        {
                            change++;
                            state = "down";
                        }
                        else if (A[i] == A[i - 1])
                            return false;
                        break;
                    case down:
                        if (A[i] > A[i - 1])
                        {
                            change++;
                            state = "up";
                        }
                        else if (A[i] == A[i - 1])
                            return false;
                        break;
                }
            }
            if (change == 1)
                return true;
            else
                return false;
        }
    }
}
