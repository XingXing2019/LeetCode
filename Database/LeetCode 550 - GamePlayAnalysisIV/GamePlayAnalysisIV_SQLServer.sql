WITH cte1 AS (SELECT COUNT(DISTINCT player_id) AS count FROM (
(SELECT *, MIN(event_date) OVER(PARTITION BY player_id ORDER BY event_date) firstLogin FROM activity)) AS t
WHERE DATEDIFF(day, event_date, firstLogin) = -1),
cte2 AS (SELECT COUNT(DISTINCT player_id) AS total FROM activity)
SELECT ROUND(CONVERT(decimal, (SELECT * FROM cte1)) / (SELECT * FROM cte2), 2) AS fraction  
