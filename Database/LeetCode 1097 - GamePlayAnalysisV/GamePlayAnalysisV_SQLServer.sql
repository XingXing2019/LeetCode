WITH Install AS (
	SELECT player_id, Min(event_date) AS InstallDate 
	FROM Activity GROUP BY player_id
)

SELECT InstallDate AS install_dt, 
COUNT(i.InstallDate) AS installs, 
ROUND(CONVERT(FLOAT, COUNT(a.event_date)) / COUNT(i.InstallDate), 2) AS Day1_retention
FROM Install i LEFT JOIN Activity a
ON i.player_id = a.player_id 
AND DATEDIFF(DAY, i.InstallDate, a.event_date) = 1 
GROUP BY i.InstallDate