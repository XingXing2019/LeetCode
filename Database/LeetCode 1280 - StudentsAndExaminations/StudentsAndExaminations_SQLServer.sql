WITH exams AS (SELECT student_id, subject_name, COUNT(*) AS attended_exams FROM examinations GROUP BY student_id, subject_name),
studentSubjects AS (SELECT * FROM students CROSS JOIN subjects)
SELECT s.student_id, s.student_name, s.subject_name, ISNULL(e.attended_exams, 0) AS attended_exams
FROM studentSubjects s LEFT JOIN exams e ON s.student_id = e.student_id AND s.subject_name = e.subject_name 
ORDER BY s.student_id, s.subject_name