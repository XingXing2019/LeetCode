package com.company;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

class Employee {
    public int id;
    public int importance;
    public List<Integer> subordinates;
}

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int getImportance(List<Employee> employees, int id) {
        Map<Integer, Employee> company = new HashMap<>();
        for (Employee employee : employees)
            company.put(employee.id, employee);
        return dfs(company.get(id), company);
    }
    public int dfs(Employee employee, Map<Integer, Employee> company){
        int res = employee.importance;
        for (int id : employee.subordinates)
            res += dfs(company.get(id), company);
        return res;
    }
}
