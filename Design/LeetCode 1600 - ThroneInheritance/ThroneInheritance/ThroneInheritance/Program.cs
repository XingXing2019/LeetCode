using System;
using System.Collections.Generic;

namespace ThroneInheritance
{
	class Program
	{
		static void Main(string[] args)
		{
			var t = new ThroneInheritance("king");
			t.Birth("king", "andy");
			t.Birth("king", "bob");
			t.Birth("king", "catherine");
			t.Birth("andy", "matthew");
			t.Birth("bob", "alex");
			t.Birth("bob", "asha");
			t.GetInheritanceOrder();
			t.Death("bob");
			t.GetInheritanceOrder();
		}
	}
	public class ThroneInheritance
	{
		class Person
		{
			public string name;
			public Dictionary<string, Person> children;
			public bool isAlive;
			public Person(string name)
			{
				this.name = name;
				children = new Dictionary<string, Person>();
				isAlive = true;
			}
		}

		private Person king;
		private Dictionary<string, Person> dict;
		public ThroneInheritance(string kingName)
		{
			king = new Person(kingName);
			dict = new Dictionary<string, Person> {{kingName, king}};
		}

		public void Birth(string parentName, string childName)
		{
			var parent = dict[parentName];
			var child = new Person(childName);
			parent.children[childName] = child;
			dict[childName] = child;
		}

		public void Death(string name)
		{
			dict[name].isAlive = false;
		}

		public IList<string> GetInheritanceOrder()
		{
			var res = new List<string>();
			DFS(king, res);
			return res;
		}

		private void DFS(Person person, List<string> order)
		{
			if (person.isAlive)
				order.Add(person.name);
			foreach (var child in person.children)
				DFS(child.Value, order);
		}
	}
}
