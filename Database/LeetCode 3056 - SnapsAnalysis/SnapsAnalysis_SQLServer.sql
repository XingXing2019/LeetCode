WITH SendTime AS (
	SELECT age_bucket, activity_type, SUM(time_spent) AS time_spent
	FROM Activities at
	JOIN Age ag ON at.user_id = ag.user_id
	WHERE activity_type = 'send'
	GROUP BY age_bucket, activity_type
),

OpenTime AS (
	SELECT age_bucket, activity_type, SUM(time_spent) AS time_spent
	FROM Activities at
	JOIN Age ag ON at.user_id = ag.user_id
	WHERE activity_type = 'open'
	GROUP BY age_bucket, activity_type
)

SELECT DISTINCT
	a.age_bucket,
	ROUND(ISNULL(s.time_spent, 0) / (ISNULL(s.time_spent, 0) + ISNULL(o.time_spent, 0)) * 100, 2) AS send_perc,
	ROUND(ISNULL(o.time_spent, 0) / (ISNULL(s.time_spent, 0) + ISNULL(o.time_spent, 0)) * 100, 2) AS open_perc
FROM Age a
LEFT JOIN OpenTime o ON a.age_bucket = o.age_bucket
LEFT JOIN SendTime s ON a.age_bucket = s.age_bucket