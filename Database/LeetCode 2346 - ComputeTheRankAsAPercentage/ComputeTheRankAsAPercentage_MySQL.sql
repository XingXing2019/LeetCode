with MarkRank as (
	select student_id, department_id, 
	rank() over(partition by department_id order by mark desc) as mark_rank,
	count(student_id) over(partition by department_id) as total_students
	from Students
)

select student_id, department_id,
case
	when total_students = 1 then 0
	else round((mark_rank - 1) * 100 / (total_students - 1), 2)
end as percentage
from MarkRank