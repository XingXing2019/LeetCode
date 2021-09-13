with junior as (
	select *, sum(salary) over (order by salary, employee_id) as sum_salary from candidates where experience = 'Junior'
),
senior as (
	select *, sum(salary) over (order by salary, employee_id) as sum_salary from candidates where experience = 'Senior'
)
select 'Senior' as experience, count(*) as accepted_candidates from senior
where sum_salary <= 70000
union all
select 'Junior' as experience, count(*) as accepted_candidates from junior
where sum_salary <= 70000 - ifnull((select max(sum_salary) from senior where sum_salary <= 70000), 0)