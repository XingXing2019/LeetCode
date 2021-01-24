select e1.reports_to as employee_id, e2.name, count(e1.employee_id) as reports_count, round(avg(CONVERT(decimal, e1.age)), 0) as average_age 
from employees e1 inner join employees e2 
on e1.reports_to  = e2.employee_id 
group by e1.reports_to, e2.name
order by employee_id
