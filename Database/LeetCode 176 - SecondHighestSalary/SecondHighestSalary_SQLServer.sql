Select MAX(e.Salary) as SecondHighestSalary from Employee e 
where e.Salary < (select MAX(Salary) from Employee);