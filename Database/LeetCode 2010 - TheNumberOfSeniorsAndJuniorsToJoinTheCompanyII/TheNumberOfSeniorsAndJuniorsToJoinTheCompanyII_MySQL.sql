with junior as (
	select *, sum(salary) over(partition by experience order by salary, employee_id) as sum_salary
    from candidates where experience = 'junior'
),

senior as (
	select *, sum(salary) over(partition by experience order by salary, employee_id) as sum_salary
    from candidates where experience = 'senior'
)

select employee_id from senior
where sum_salary <= 70000
union all
select employee_id from junior
where sum_salary < 70000 - ifnull((select max(sum_salary) from senior where sum_salary < 70000), 0)