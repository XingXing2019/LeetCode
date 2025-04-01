WITH Activities AS (
	SELECT user_id, activity_type, SUM(activity_duration) * 1.0 / COUNT(*) AS avg_duration
	FROM UserActivity
	WHERE activity_type IN ('free_trial', 'paid')
	GROUP BY user_id, activity_type
)

SELECT a1.user_id, ROUND(a1.avg_duration, 2) AS trial_avg_duration, ROUND(a2.avg_duration, 2) AS paid_avg_duration
FROM Activities a1
LEFT JOIN Activities a2 ON a1.user_id = a2.user_id
WHERE a1.activity_type = 'free_trial'
AND a2.activity_type = 'paid'