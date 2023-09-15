SELECT
	s1.user_id AS user_id,
	s3.steps_date AS steps_date, 
	ROUND(CONVERT(FLOAT, (s1.steps_count + s2.steps_count + s3.steps_count)) / 3, 2) AS rolling_average
FROM Steps s1
JOIN Steps s2 
ON s1.user_id = s2.user_id AND DATEDIFF(DAY, s1.steps_date, s2.steps_date) = 1
JOIN Steps s3
ON s2.user_id = s3.user_id AND DATEDIFF(DAY, s2.steps_date, s3.steps_date) = 1
ORDER BY user_id, steps_date