SELECT s.student_id
FROM courses c
LEFT JOIN students s ON s.major = c.major
LEFT JOIN enrollments e ON s.student_id = e.student_id AND c.course_id = e.course_id
GROUP BY s.student_id
HAVING MAX(ISNULL(grade, 'Z')) = 'A'
ORDER BY s.student_id