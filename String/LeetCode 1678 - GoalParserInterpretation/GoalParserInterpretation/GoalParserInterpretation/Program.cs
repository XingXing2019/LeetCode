using System;

namespace GoalParserInterpretation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static string Interpret(string command)
        {
            var res = command[0] == 'G' ? "G" : "";
            for (int i = 1; i < command.Length; i++)
            {
                if (command[i] == 'G')
                    res += 'G';
                else if (command[i] == ')')
                    res += command[i - 1] == '(' ? "o" : "al";
            }
            return res;
        }
    }
}
