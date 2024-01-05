WITH SessionRank AS (
	SELECT *, RANK() OVER(PARTITION BY user_id ORDER BY session_start) AS session_rank
	FROM Sessions
)

SELECT user_id, COUNT(session_id) AS sessions_count
FROM Sessions
WHERE user_id IN (
	SELECT user_id FROM SessionRank 
	WHERE session_rank = 1 
	AND session_type = 'Viewer'
)
AND session_type = 'Streamer'
GROUP BY user_id
HAVING SUM(CASE WHEN session_type = 'Streamer' THEN 1 ELSE 0 END) <> 0
ORDER BY COUNT(session_id) DESC, user_id DESC