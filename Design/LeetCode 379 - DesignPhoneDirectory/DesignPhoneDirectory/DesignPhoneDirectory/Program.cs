using System;
using System.Collections.Generic;

namespace DesignPhoneDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            var phone = new PhoneDirectory(2);
            phone.Release(1);
            Console.WriteLine(phone.Get());
            Console.WriteLine(phone.Check(1));
            Console.WriteLine(phone.Check(1));
            phone.Release(1);
            Console.WriteLine(phone.Check(1));
            Console.WriteLine(phone.Get());
            Console.WriteLine(phone.Check(0));
            Console.WriteLine(phone.Check(1));
            Console.WriteLine(phone.Check(1));
        }
    }
    public class PhoneDirectory
    {
        private int[] record;
        public PhoneDirectory(int maxNumbers)
        {
            record = new int[maxNumbers];
            for (int i = 0; i < maxNumbers; i++)
                record[i]++;
        }

        public int Get()
        {
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] > 0)
                {
                    record[i]--;
                    return i;
                }
            }
            return -1;
        }

        public bool Check(int number)
        {
            return record[number] > 0;
        }

        public void Release(int number)
        {
            if (record[number] == 0)
                record[number]++;
        }
    }

}
