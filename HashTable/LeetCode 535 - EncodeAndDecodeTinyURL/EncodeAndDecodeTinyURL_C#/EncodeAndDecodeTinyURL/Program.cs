using System;
using System.Collections.Generic;

namespace EncodeAndDecodeTinyURL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class Codec
    {
        private List<string> record = new List<string>();
        public string encode(string longUrl)
        {
            record.Add(longUrl);
            var index = record.Count - 1;
            return index.ToString();
        }

        public string decode(string shortUrl)
        {
            int index = int.Parse(shortUrl);
            return record[index];
        }
    }
}
