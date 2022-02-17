WITH Win_Count AS (
	SELECT *, SUM(IIF(result = 'win', 0, 1)) OVER(PARTITION BY player_id ORDER BY match_day) AS win_count FROM Matches
),

Streak AS (
	SELECT player_id, win_count, COUNT(*) - SUM(IIF(result = 'win', 0, 1)) AS streak 
	FROM Win_Count
	GROUP BY player_id, win_count
)

SELECT player_id, MAX(streak) AS longest_streak
FROM Streak
GROUP BY player_id