using System;

namespace MinimumNumberOfFrogsCroaking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MinNumberOfFrogs(string croakOfFrogs)
        {
            int countC = 0, countR = 0, countO = 0, countA = 0;
            int countFrog = 0, minFrog = 0;
            foreach (var c in croakOfFrogs)
            {
                switch (c)
                {
                    case 'c':
                        countC++;
                        countFrog++;
                        minFrog = Math.Max(minFrog, countFrog);
                        break;
                    case 'r':
                        countR++;
                        break;
                    case 'o':
                        countO++;
                        break;
                    case 'a':
                        countA++;
                        break;
                    case 'k':
                        countFrog--;
                        break;
                }
                if (countC < countR || countR < countO || countO <countA)
                    return -1;
            }
            return countFrog == 0 ? minFrog : -1;
        }
    }
}
