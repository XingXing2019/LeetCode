SELECT t1.player_id, t1.device_id
FROM activity t1 JOIN (
	SELECT player_id, MIN(event_date) AS first_login
	FROM activity
	GROUP BY player_id
) AS t2
ON t1.player_id = t2.player_id
WHERE t1.event_date = t2.first_login;