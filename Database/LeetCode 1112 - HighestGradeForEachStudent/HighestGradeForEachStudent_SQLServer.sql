WITH cte AS (SELECT *, RANK() OVER(PARTITION BY student_id ORDER BY grade DESC, course_id ASC) AS rank FROM enrollments)
SELECT student_id, course_id, grade FROM cte WHERE rank = 1