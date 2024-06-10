select s.student_id
from courses c
left join students s on c.major = s.major
left join enrollments e on s.student_id = e.student_id and c.course_id = e.course_id
group by s.student_id
having max(ifnull(e.grade, 'Z')) = 'A'
order by s.student_id