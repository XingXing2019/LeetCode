using System;
using System.Collections.Generic;
using System.Linq;

namespace SatisfiabilityOfEqualityEquations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] equations = { "a==b", "b!=a" };
            Console.WriteLine(EquationsPossible(equations));
        }
        
        public static bool EquationsPossible(string[] equations)
        {
            var parents = new Dictionary<char, char>();
            var rank = new Dictionary<char, int>();
            for (int i = 0; i < 26; i++)
            {
                var letter = (char)(i + 'a');
                parents[letter] = letter;
                rank[letter] = 0;
            }
            foreach (var equation in equations)
            {
                if (equation[1] == '!') continue;
                Union(equation[0], equation[^1], parents, rank);
            }
            foreach (var equation in equations)
            {
                if (equation[1] == '=') continue;
                if (Find(equation[0], parents) == Find(equation[^1], parents))
                    return false;
            }
            return true;
        }

        public static char Find(char x, Dictionary<char, char> parents)
        {
            if (parents[x] != x)
                parents[x] = Find(parents[x], parents);
            return parents[x];
        }

        public static void Union(char x, char y, Dictionary<char, char> parents, Dictionary<char, int> rank)
        {
            char rootX = Find(x, parents), rootY = Find(y, parents);
            if (rootX == rootY)
                return;
            if (rank[rootX] >= rank[rootY])
            {
                parents[rootY] = rootX;
                if (rank[rootX] == rank[rootY])
                    rank[rootX]++;
            }
            else
                parents[rootX] = rootY;
        }
    }
}
