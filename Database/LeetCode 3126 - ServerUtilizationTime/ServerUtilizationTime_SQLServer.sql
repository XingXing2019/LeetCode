WITH SessionTime AS (
	SELECT session_status, status_time AS start_time,
	LEAD(status_time, 1) OVER(PARTITION BY server_id ORDER BY status_time ASC, session_status ASC) AS end_time
	FROM Servers
)

SELECT FLOOR(SUM(DATEDIFF(SECOND, start_time, end_time)) * 1.0 / 24 / 60 / 60) AS total_uptime_days
FROM SessionTime
WHERE session_status = 'start'