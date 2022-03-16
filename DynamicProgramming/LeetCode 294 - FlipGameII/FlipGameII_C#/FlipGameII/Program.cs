using System;
using System.Collections.Generic;
using System.Linq;

namespace FlipGameII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var currentState = "+";
            Console.WriteLine(CanWin(currentState));
        }

        public static bool CanWin(string currentState)
        {
            var dp = new Dictionary<string, int[]>();
            return DFS(currentState, 0, dp) == 1;
        }

        public static int DFS(string currentState, int turn, Dictionary<string, int[]> dp)
        {
            if (!dp.ContainsKey(currentState))
                dp[currentState] = new int[2];
            if (dp[currentState][turn % 2] != 0)
                return dp[currentState][turn % 2];
            var nextStates = GetNextStates(currentState);
            if (nextStates.Count == 0)
                return turn % 2 == 0 ? 2 : 1;
            if (turn % 2 == 0)
            {
                if (nextStates.Any(x => DFS(x, turn + 1, dp) == 1))
                    return dp[currentState][turn % 2] = 1;
                return dp[currentState][turn % 2] = 2;
            }
            else
            {
                if (nextStates.Any(x => DFS(x, turn + 1, dp) == 2))
                    return dp[currentState][turn % 2] = 2;
                return dp[currentState][turn % 2] = 1;
            }
        }

        public static List<string> GetNextStates(string currentState)
        {
            var nextStates = new List<string>();
            for (int i = 0; i < currentState.Length - 1; i++)
            {
                if (currentState[i] != '+' || currentState[i + 1] != '+') continue;
                var nextState = $"{currentState.Substring(0, i)}--{currentState.Substring(i + 2)}";
                nextStates.Add(nextState);
            }
            return nextStates;
        }
    }
}
