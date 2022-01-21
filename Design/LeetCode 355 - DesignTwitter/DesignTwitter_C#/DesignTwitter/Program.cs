using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignTwitter
{
    class Program
    {
        static void Main(string[] args)
        {
            var twitter = new Twitter();
            twitter.PostTweet(1, 5);
            twitter.GetNewsFeed(1);
            twitter.Follow(1, 2);
            twitter.PostTweet(2, 6);
            twitter.GetNewsFeed(1);
            twitter.Unfollow(1, 2);
            twitter.GetNewsFeed(1);
        }
    }
    public class Twitter1
    {
        private Dictionary<int, HashSet<int>> follow;
        private List<int[]> messages;
        public Twitter1()
        {
            follow = new Dictionary<int, HashSet<int>>();
            messages = new List<int[]>();
        }

        public void PostTweet(int userId, int tweetId)
        {
            if(!follow.ContainsKey(userId))
                follow[userId] = new HashSet<int>{userId};
            else
                follow[userId].Add(userId);
            messages.Add(new int[] { userId, tweetId });
        }

        public IList<int> GetNewsFeed(int userId)
        {
            var res = new List<int>();
            var followees = new List<int>{userId};
            if(follow.ContainsKey(userId))
                followees.AddRange(follow[userId]);
            for (int i = messages.Count - 1; i >= 0 && res.Count < 10; i--)
            {
                if(messages[i][0] == userId || followees.Contains(messages[i][0]))
                    res.Add(messages[i][1]);
            }
            return res;
        }

        public void Follow(int followerId, int followeeId)
        {
            if (!follow.ContainsKey(followerId))
                follow[followerId] = new HashSet<int>{ followeeId };
            else
                follow[followerId].Add(followeeId);
        }

        public void Unfollow(int followerId, int followeeId)
        {
            if (follow.ContainsKey(followerId))
                follow[followerId].Remove(followeeId);
        }
    }

    public class Twitter
    {
        class User
        {
            public List<Message> messages;
            public Dictionary<int, User> followees;
            public User()
            {
                messages = new List<Message>();
                followees = new Dictionary<int, User>();
            }
        }

        class Message
        {
            public int id;
            public int timestamp;

            public Message(int id, int timestamp)
            {
                this.id = id;
                this.timestamp = timestamp;
            }
        }

        private Dictionary<int, User> _users;
        private int _timestamp;

        public Twitter()
        {
            _users = new Dictionary<int, User>();
            _timestamp = 0;
        }

        public void PostTweet(int userId, int tweetId)
        {
            if (!_users.ContainsKey(userId)) _users[userId] = new User();
            _users[userId].messages.Add(new Message(tweetId, _timestamp++));
        }

        public IList<int> GetNewsFeed(int userId)
        {
            if (!_users.ContainsKey(userId)) return new List<int>();
            var msgs = new List<Message>();
            var user = _users[userId];
            msgs.AddRange(user.messages);
            msgs.AddRange(user.followees.Values.SelectMany(x => x.messages));
            return msgs.OrderByDescending(x => x.timestamp).Take(10).Select(x => x.id).ToList();
        }

        public void Follow(int followerId, int followeeId)
        {
            if (!_users.ContainsKey(followerId)) _users[followerId] = new User();
            if (!_users.ContainsKey(followeeId)) _users[followeeId] = new User();
            _users[followerId].followees.TryAdd(followeeId, _users[followeeId]);
        }

        public void Unfollow(int followerId, int followeeId) => _users[followerId].followees.Remove(followeeId);
    }
}
