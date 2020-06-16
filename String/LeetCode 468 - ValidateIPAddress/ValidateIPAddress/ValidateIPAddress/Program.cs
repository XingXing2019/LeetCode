//按照要求检查IP地址。多错几次就知道规则了。
using System;

namespace ValidateIPAddress
{
    class Program
    {
        static void Main(string[] args)
        {
            string IP = "192.0.0.1";
            Console.WriteLine(ValidIPAddress(IP));
        }
        static string ValidIPAddress(string IP)
        {
            if (IsIPv4(IP)) return "IPv4";
            if (IsIPv6(IP)) return "IPv6";
            return "Neither";
        }

        static bool IsIPv4(string IP)
        {
            if (!IP.Contains('.')) return false;
            var parts = IP.Split('.');
            if (parts.Length != 4) return false;
            foreach (var part in parts)
            {
                if (part == "" || (part.Length > 1 && part[0] == '0') || part[0] == '-') return false;
                int num;
                bool canParse = int.TryParse(part, out num);
                if (!canParse) return false;
                if (num > 255 || num < 0) return false;
            }
            return true;
        }

        static bool IsIPv6(string IP)
        {
            if (!IP.Contains(':')) return false;
            var parts = IP.Split(':');
            if (parts.Length != 8) return false;
            foreach (var part in parts)
            {
                if (part == "" || part[0] == '-') return false;
                if (part.Length > 4) return false;
                for (int i = 0; i < part.Length; i++)
                {
                    if (Char.IsLetter(part[i]) && Char.ToLower(part[i]) >= 'g')
                        return false;
                }
            }
            return true;
        }
    }
}
