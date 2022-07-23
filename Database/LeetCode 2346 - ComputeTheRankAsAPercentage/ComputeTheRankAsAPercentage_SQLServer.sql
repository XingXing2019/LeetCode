WITH MarkRank AS (
	SELECT *, RANK() OVER(PARTITION BY department_id ORDER BY mark DESC) AS mark_rank, 
	COUNT(*) OVER(PARTITION BY department_id) AS total_students
	FROM Students
)

SELECT student_id, department_id, 
CASE
	WHEN total_students = 1 THEN 0
	ELSE ROUND(CONVERT(FLOAT, (mark_rank - 1)) * 100 / (total_students - 1), 2)
END AS percentage
FROM MarkRank