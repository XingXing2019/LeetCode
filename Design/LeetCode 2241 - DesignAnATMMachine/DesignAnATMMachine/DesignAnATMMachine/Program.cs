using System;

namespace DesignAnATMMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var atm = new ATM();
            atm.Deposit(new []{0, 0, 1, 2, 1});
            atm.Withdraw(300); 
            atm.Deposit(new[] { 0, 1, 0, 1, 1 });
            atm.Withdraw(600);
            atm.Withdraw(550);
        }
    }

    public class ATM
    {
        private long[] notes;
        private long[] cash;
        public ATM()
        {
            notes = new long[5];
            cash = new long[] {20, 50, 100, 200, 500};
        }

        public void Deposit(int[] banknotesCount)
        {
            for (int i = 0; i < banknotesCount.Length; i++)
                notes[i] += banknotesCount[i];
        }

        public int[] Withdraw(int amount)
        {
            var res = new int[5];
            var copy = new long[5];
            Array.Copy(notes, copy, copy.Length);
            for (int i = notes.Length - 1; i >= 0; i--)
            {
                if (amount < cash[i]) continue;
                long count = Math.Min(notes[i], amount / cash[i]);
                notes[i] -= count;
                amount -= (int) (cash[i] * count);
                res[i] = (int) count;
            }
            if (amount == 0) return res;
            notes = copy;
            return new[] { -1 };
        }
    }
}
