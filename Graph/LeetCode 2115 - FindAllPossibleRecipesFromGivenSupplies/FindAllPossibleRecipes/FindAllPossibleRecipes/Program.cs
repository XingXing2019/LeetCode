
using System;
using System.Collections.Generic;

namespace FindAllPossibleRecipes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] recipes = { "zpmcz", "h", "q" };
            IList<IList<string>> ingredients = new List<IList<string>>
            {
                new List<string> { "h", "fzjnm", "e", "q", "x" },
                new List<string> { "d", "hveml", "cpivl", "q", "zpmcz", "ju", "e", "x" },
                new List<string> { "f", "hveml", "cpivl" },
            };
            string[] supplies = { "f", "hveml", "cpivl", "d" };
            FindAllRecipes(recipes, ingredients, supplies);
        }
        public static IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
        {
            var graph = new Dictionary<string, List<string>>();
            for (int i = 0; i < recipes.Length; i++)
                graph[recipes[i]] = new List<string>(ingredients[i]);
            var s = new HashSet<string>(supplies);
            var res = new List<string>();
            var found = new HashSet<string>();
            foreach (var recipe in recipes)
            {
                if (DFS(recipe, graph, s, found, new HashSet<string>()))
                    res.Add(recipe);
            }
            return res;
        }

        public static bool DFS(string cur, Dictionary<string, List<string>> graph, HashSet<string> supplies, HashSet<string> found, HashSet<string> visited)
        {
            if (supplies.Contains(cur) || found.Contains(cur)) return true;
            if (!graph.ContainsKey(cur) || !visited.Add(cur)) return false;
            foreach (var next in graph[cur])
            {
                if (!DFS(next, graph, supplies, found, visited))
                    return false;
            }
            found.Add(cur);
            return true;
        }
    }
}
