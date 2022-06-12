SELECT * FROM (
	SELECT COUNT(*) AS weekend_cnt FROM Tasks
	WHERE DATEPART(WEEKDAY, submit_date) IN (1, 7)
) AS Weekend
JOIN (
	SELECT COUNT(*) AS working_cnt FROM Tasks
	WHERE DATEPART(WEEKDAY, submit_date) NOT IN (1, 7)
) AS WorkingDay ON 1 = 1