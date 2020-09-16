using System;
using System.Collections.Generic;

namespace DesignSnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 3, height = 3;
            int[][] food = new int[][]
            {
                new int[]{2, 0}, 
                new int[]{0, 0}, 
                new int[]{0, 2}, 
                new int[]{2, 2}, 
            };
            var obj = new SnakeGame(width, height, food);
            Console.WriteLine(obj.Move("D"));
            Console.WriteLine(obj.Move("D"));
            Console.WriteLine(obj.Move("R"));
            Console.WriteLine(obj.Move("U"));
            Console.WriteLine(obj.Move("U"));
            Console.WriteLine(obj.Move("L"));
            Console.WriteLine(obj.Move("D"));
            Console.WriteLine(obj.Move("R"));
            Console.WriteLine(obj.Move("R"));
            Console.WriteLine(obj.Move("U"));
            Console.WriteLine(obj.Move("L"));
            Console.WriteLine(obj.Move("D"));
        }
    }
    public class SnakeGame
    {
        private int[][] board;
        private Queue<string> snake;
        private Queue<int[]> foodPos;
        private HashSet<string> record;
        int[] head;
        public SnakeGame(int width, int height, int[][] food)
        {
            snake = new Queue<string>();
            record = new HashSet<string>();
            head = new[] {0, 0};
            snake.Enqueue("0:0");
            board = new int[height][];
            for (int i = 0; i < board.Length; i++)
                board[i] = new int[width];
            foodPos = new Queue<int[]>(food);
        }

        public int Move(string direction)
        {
            if (direction == "U")
                head[0] -= 1;
            else if (direction == "D")
                head[0] += 1;
            else if (direction == "L")
                head[1] -= 1;
            else
                head[1] += 1;
            if (head[0] < 0 || head[0] >= board.Length || head[1] < 0 || head[1] >= board[0].Length)
                return -1;
            if (foodPos.Count != 0 && head[0] == foodPos.Peek()[0] && head[1] == foodPos.Peek()[1])
                foodPos.Dequeue();
            else
                record.Remove(snake.Dequeue());
            if (record.Contains($"{head[0]}:{head[1]}"))
                return -1;
            snake.Enqueue($"{head[0]}:{head[1]}");
            record.Add($"{head[0]}:{head[1]}");
            return snake.Count - 1;
        }
    }
}
