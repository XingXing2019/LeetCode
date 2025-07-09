WITH meeting_week AS (
	SELECT employee_id, DATEPART(WEEK, DATEADD(DAY, -1, meeting_date)) AS meeting_week, duration_hours 
	FROM meetings
)

SELECT e.employee_id, employee_name, department, meeting_heavy_weeks
FROM (
	SELECT employee_id, COUNT(*) AS meeting_heavy_weeks FROM (
		SELECT employee_id, meeting_week
		FROM meeting_week
		GROUP BY employee_id, meeting_week
		HAVING SUM(duration_hours) > 20
	) AS t1
	GROUP BY employee_id
	HAVING COUNT(*) > 1
) AS t2
JOIN employees e ON e.employee_id = t2.employee_id
ORDER BY meeting_heavy_weeks DESC, employee_name