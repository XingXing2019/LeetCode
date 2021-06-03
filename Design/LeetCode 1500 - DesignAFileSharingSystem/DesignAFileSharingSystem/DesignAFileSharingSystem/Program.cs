using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignAFileSharingSystem
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
	}
	public class FileSharing
	{
		private int id;
		private List<int> avaliableIds;
		private Dictionary<int, HashSet<int>> system;
		public FileSharing(int m)
		{
			id = 1;
			avaliableIds = new List<int>();
			system = new Dictionary<int, HashSet<int>>();
		}

		public int Join(IList<int> ownedChunks)
		{
			var userId = 0;
			if (avaliableIds.Count != 0)
			{
				userId = avaliableIds[^1];
				avaliableIds.RemoveAt(avaliableIds.Count - 1);
			}
			else
				userId = id++;
			system[userId] = new HashSet<int>(ownedChunks);
			return userId;
		}

		public void Leave(int userID)
		{
			system.Remove(userID);
			avaliableIds.Add(userID);
			avaliableIds.Sort((a, b) => b - a);
		}

		public IList<int> Request(int userID, int chunkID)
		{
			var res = new List<int>();
			foreach (var item in system)
			{
				if(item.Value.Contains(chunkID))
					res.Add(item.Key);
			}
			if (res.Count == 0)
				return res;
			system[userID].Add(chunkID);
			res.Sort();
			return res;
		}
	}
}
