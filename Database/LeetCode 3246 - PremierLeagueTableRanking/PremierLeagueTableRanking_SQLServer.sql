SELECT * FROM (
	SELECT *, RANK() OVER(ORDER BY points DESC) AS position
	FROM (
		SELECT team_id, team_name, wins * 3 + draws AS points
		FROM TeamStats
	) AS t
) AS t
ORDER BY position, team_name

