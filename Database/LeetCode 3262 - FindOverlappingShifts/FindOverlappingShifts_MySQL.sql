select e1.employee_id, count(*) as overlapping_shifts 
from EmployeeShifts e1
left join EmployeeShifts e2
on e1.employee_id = e2.employee_id
and e1.start_time <> e2.start_time
and e1.end_time > e2.start_time
and e1.start_time < e2.start_time
where e2.employee_id is not null
group by e1.employee_id
order by e1.employee_id