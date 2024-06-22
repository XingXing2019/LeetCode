select student_id from (
	select s.student_id
	from Courses c
	join Students s on s.major = c.major
	left join Enrollments e on e.student_id = s.student_id
	and e.course_id = c.course_id
	where c.mandatory = 'yes'
	group by s.student_id
	having max(ifnull(e.grade, 'Z')) = 'A'
) as t
where student_id in (
	select s.student_id
	from Courses c
	join Students s on s.major = c.major
	left join Enrollments e on e.student_id = s.student_id
	and e.course_id = c.course_id
	where c.mandatory = 'no'
	group by s.student_id
	having max(e.grade) <= 'B' 
    and count(e.student_id) >= 2
)
and student_id in (
	select e.student_id
    from Enrollments e
    group by e.student_id
    having avg(e.GPA) >= 2.5
)
order by student_id
