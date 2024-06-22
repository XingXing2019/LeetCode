SELECT student_id FROM (
	SELECT s.student_id
	FROM Courses c
	JOIN Students s ON s.major = c.major
	LEFT JOIN Enrollments e ON e.student_id = s.student_id
	AND e.course_id = c.course_id
	WHERE c.mandatory = 'yes'
	GROUP BY s.student_id
	HAVING MAX(ISNULL(e.grade, 'Z')) = 'A'
) AS t
WHERE student_id IN (
	SELECT s.student_id
	FROM Courses c
	JOIN Students s ON s.major = c.major
	LEFT JOIN Enrollments e ON e.student_id = s.student_id
	AND e.course_id = c.course_id
	WHERE c.mandatory = 'no'
	GROUP BY s.student_id
	HAVING MAX(e.grade) <= 'B'
	AND COUNT(e.student_id) >= 2
)	   
AND student_id IN (
	SELECT e.student_id 
	FROM Enrollments e
	GROUP BY e.student_id
	HAVING AVG(e.GPA) >= 2.5
)
ORDER BY student_id