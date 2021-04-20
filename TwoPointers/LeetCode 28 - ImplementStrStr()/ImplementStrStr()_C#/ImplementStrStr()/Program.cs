//创建res代表结果，初始值设为-1。从第一个元素到haystack.Length - needle.Length(包含)的范围内遍历haystack。
//当发现当前遍历到的字母和needle第一个字母相同时，从当前字母向后截取needle.Length的子串。如果该子串与needle相同，则将res设为当前i值，并停止遍历。
//最后返回res。
using System;
using System.Text;

namespace ImplementStrStr__
{
	class Program
	{
		static void Main(string[] args)
		{
			string haystack = "hello", needle = "ll";
			Console.WriteLine(StrStr_RabinKarp(haystack, needle));
		}
		static int StrStr(string haystack, string needle)
		{
			if (needle == "")
				return 0;
			int res = -1;
			for (int i = 0; i <= haystack.Length - needle.Length; i++)
			{
				if (haystack[i] == needle[0])
				{
					string tem = haystack.Substring(i, needle.Length);
					if (tem == needle)
					{
						res = i;
						break;
					}
				}
			}
			return res;
		}
		static int StrStr_StringBuilder(string haystack, string needle)
		{
			if (haystack.Length < needle.Length) return -1;
			var strH = new StringBuilder(haystack.Substring(0, needle.Length));
			if (strH.Equals(needle)) return 0;
			for (int i = needle.Length; i < haystack.Length; i++)
			{
				strH.Remove(0, 1);
				strH.Append(haystack[i]);
				if (strH.Equals(needle)) return i - needle.Length + 1;
			}
			return -1;
		}

		static int StrStr_RabinKarp(string haystack, string needle)
		{
			if (haystack.Length < needle.Length) return -1;
			int pow = 1, prime = 101, time = 256;
			int hHash = 0, nHash = 0;
			for (int i = 0; i < needle.Length - 1; i++)
				pow = pow * time % prime;
			for (int i = 0; i < needle.Length; i++)
			{
				hHash = (hHash * time + haystack[i]) % prime;
				nHash = (nHash * time + needle[i]) % prime;
			}
			for (int i = 0; i <= haystack.Length - needle.Length; i++)
			{
				if (hHash == nHash)
				{
					int len = 0;
					while (len < needle.Length)
					{
						if (needle[len] != haystack[i + len])
							break;
						len++;
					}
					if (len == needle.Length) return i;
				}
				else
				{
					if (i + needle.Length >= haystack.Length) break;
					hHash = ((hHash - haystack[i] * pow) * time + haystack[i + needle.Length]) % prime;
					if (hHash < 0) hHash += prime;
				}
			}
			return -1;
		}
	}
}

