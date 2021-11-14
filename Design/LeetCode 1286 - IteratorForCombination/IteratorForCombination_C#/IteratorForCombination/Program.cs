//先用DFS找出所有组合，存入一个列表。
//再用以这个指针根据要求返回Next和HasNext
using System.Collections.Generic;
using System.Text;

namespace IteratorForCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            string characters = "abc";
            int combinationLength = 3;
            var iterator = new CombinationIterator(characters, combinationLength);
        }
    }
    public class CombinationIterator
    {
        private List<string> combinations;
        private int pointer;
        public CombinationIterator(string characters, int combinationLength)
        {
            combinations = new List<string>();
            var combination = new StringBuilder();
            DFS(characters, combinationLength, 0, combination);
        }

        private void DFS(string characters, int combinationLength, int start, StringBuilder combination)
        {
            if (combination.Length == combinationLength)
                combinations.Add(combination.ToString());
            for (int i = start; i < characters.Length; i++)
            {
                combination.Append(characters[i]);
                DFS(characters, combinationLength, i + 1, combination);
                combination.Remove(combination.Length - 1, 1);
            }
        }

        public string Next()
        {
            return combinations[pointer++];
        }

        public bool HasNext()
        {
            return pointer != combinations.Count;
        }
    }

}
