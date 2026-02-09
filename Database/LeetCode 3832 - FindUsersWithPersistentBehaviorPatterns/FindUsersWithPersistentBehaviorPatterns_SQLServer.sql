WITH streak AS (
	SELECT *, DATEDIFF(DAY, action_date, diff) AS streak_length
	FROM (
		SELECT *, DATEADD(DAY, 1 * ROW_NUMBER() OVER(PARTITION BY user_id, action ORDER BY action_date DESC), action_date) AS diff
		FROM activity
	) AS t
)

SELECT user_id, action, streak_length, action_date AS start_date, DATEADD(DAY, streak_length - 1, action_date) AS end_date
FROM (
	SELECT *, RANK() OVER(PARTITION BY user_id, action ORDER BY streak_length DESC) AS rank
	FROM streak
	WHERE streak_length >= 5
) AS t
WHERE rank = 1
ORDER BY streak_length DESC, user_id