select student_id, course_id, grade from 
(select *, rank() over(partition by student_id order by grade desc, course_id asc) as 'rank' from enrollments) as t
where t.rank = 1
