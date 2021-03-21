using System;
using System.Linq;
using System.Collections.Generic;

namespace DesignAuthenticationManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class AuthenticationManager
    {
        private Dictionary<string, int> expireAt;
        private int liveTime;
        public AuthenticationManager(int timeToLive)
        {
            expireAt = new Dictionary<string, int>();
            liveTime = timeToLive;
        }

        public void Generate(string tokenId, int currentTime)
        {
            expireAt[tokenId] = currentTime + liveTime;
        }

        public void Renew(string tokenId, int currentTime)
        {
            if(!expireAt.ContainsKey(tokenId) || expireAt[tokenId] <= currentTime)
                return;
            expireAt[tokenId] = currentTime + liveTime;
        }

        public int CountUnexpiredTokens(int currentTime)
        {
            return expireAt.Count(x => x.Value > currentTime);
        }
    }

}
