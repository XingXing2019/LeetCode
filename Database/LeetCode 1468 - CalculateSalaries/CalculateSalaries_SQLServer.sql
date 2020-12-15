select t1.company_id, t1.employee_id, t1.employee_name, (
	case when t2.max < 1000 then convert(int, round(t1.salary, 0))
	when t2.max <= 10000 then convert(int, round(t1.salary * 0.76, 0))
	else convert(int, round(t1.salary * 0.51, 0)) end
) as salary  from (
select * from salaries s1) as t1
left join
(select s2.company_id, max(s2.salary) max from salaries s2 group by company_id) as t2
on t1.company_id = t2.company_id;



