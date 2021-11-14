using System;

namespace TimeNeededToBuyTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tickets = { 5, 1, 1, 1 };
            int k = 0;
            Console.WriteLine(TimeRequiredToBuy(tickets, k));
        }
        public static int TimeRequiredToBuy(int[] tickets, int k)
        {
            int res = 0;
            while (tickets[k] != 0)
            {
                for (int i = 0; i < tickets.Length; i++)
                {
                    if (tickets[i] == 0) continue;
                    tickets[i]--;
                    res++;
                    if (tickets[k] == 0) return res;
                }
            }
            return res;
        }
    }
}
