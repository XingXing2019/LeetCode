select t1.student_id, t1.student_name, t1.subject_name, ifnull(t2.attended_exams, 0) attended_exams
from
(select * from students, subjects) t1
left join
(select *, count(subject_name) attended_exams
from examinations
group by student_id, subject_name) t2
on t1.student_id = t2.student_id and t1.subject_name = t2.subject_name
order by t1.student_id, t1.subject_name;