with salaryRank as (select *, rank() over(partition by company order by salary) as salaryRank from employee),
employeeCount as (select company, count(*) as total from salaryRank group by company),
results as (select s.id, s.company, s.salary from salaryRank s right join employeeCount e on s.company = e.company
where s.salaryRank = floor((e.total + 1) / 2) or s.salaryRank = floor((e.total + 2) / 2))
select min(id) as id, company, salary from results group by salary, company