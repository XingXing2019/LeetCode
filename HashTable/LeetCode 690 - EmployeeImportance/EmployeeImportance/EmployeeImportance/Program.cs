using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeImportance
{
    class Employee
    {
        // It's the unique id of each node;
        // unique id of this employee
        public int id;
        // the importance value of this employee
        public int importance;
        // the id of direct subordinates
        public IList<int> subordinates;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>();
            employees.Add(new Employee {id = 1, importance = 5, subordinates = new List<int> {2, 3}});
            employees.Add(new Employee {id = 2, importance = 3, subordinates = new List<int> {4}});
            employees.Add(new Employee {id = 3, importance = 4, subordinates = new List<int> {}});
            employees.Add(new Employee {id = 4, importance = 1, subordinates = new List<int> {}});

            Console.WriteLine(GetImportance(employees, 1));
        }
        static int GetImportance(IList<Employee> employees, int id)
        {
            int importance = 0;
            var dict = new Dictionary<int, Employee>();
            foreach (var employee in employees)
                dict.Add(employee.id, employee);
            DFS(dict, id, ref importance);
            return importance;
        }

        static void DFS(Dictionary<int, Employee> dict, int curId, ref int importance)
        {
            if(dict[curId] == null)
                return;
            importance += dict[curId].importance;
            foreach (var subordinate in dict[curId].subordinates)
                DFS(dict, subordinate, ref importance);
        }
    }
}
