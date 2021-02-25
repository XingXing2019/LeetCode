with topScore as (select student_id, rank() over(partition by exam_id order by score desc) as top from exam),
bottomScore as (select student_id, rank() over(partition by exam_id order by score) as bottom from exam),
topBottomStudents as (select distinct student_id from (select * from topScore where top = 1 union all select * from bottomScore where bottom = 1) as t)

select * from student where student_id not in (select * from topBottomStudents)
and student_id in (select distinct student_id from exam) order by student_id