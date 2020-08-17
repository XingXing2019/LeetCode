SELECT login_date, COUNT(*) user_count
FROM (
	SELECT user_id, MIN(activity_date) AS login_date 
	FROM traffic
	WHERE activity = 'login'
	GROUP BY user_id
) s
WHERE DATEDIFF ('2019-06-30', login_date) <= 90
GROUP BY login_date;