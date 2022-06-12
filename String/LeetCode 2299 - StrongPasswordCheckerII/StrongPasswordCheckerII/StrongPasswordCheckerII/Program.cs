using System;
using System.Collections.Generic;
using System.Linq;

namespace StrongPasswordCheckerII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool StrongPasswordCheckerII(string password)
        {
            var specials = new HashSet<char>("!@#$%^&*()-+");
            bool hasUpper = false, hasLower = false, hasSpecial = false, hasDigigt = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsUpper(password[i]))
                    hasUpper = true;
                if (char.IsLower(password[i]))
                    hasLower = true;
                if (char.IsDigit(password[i]))
                    hasDigigt = true;
                if (specials.Contains(password[i]))
                    hasSpecial = true;
                if (i != 0 && password[i] == password[i - 1])
                    return false;
            }
            return password.Length >= 8 && hasUpper && hasLower && hasSpecial && hasDigigt;
        }
    }
}
