WITH Position AS (
	SELECT *, RANK() OVER(ORDER BY points DESC) AS position 
	FROM (
		SELECT team_name, wins * 3 + draws AS points
		FROM TeamStats
	) AS t1
)

SELECT *,
CASE	
	WHEN position <= CEILING((SELECT COUNT(*) FROM Position) * 0.33) THEN 'Tier 1'
	WHEN position > CEILING((SELECT COUNT(*) FROM Position) * 0.66) THEN 'Tier 3'
	ELSE 'Tier 2'
END AS tier
FROM Position 
ORDER BY points DESC, team_name	