WITH Scores AS (
	SELECT t1.team_name, CONVERT(INT, SUBSTRING(time_stamp, 1, 2)) * 60 + CONVERT(INT, SUBSTRING(time_stamp, 4, 2)) AS Time,
	CASE
		WHEN t1.team_name = t2.team_name THEN 1
		ELSE -1
	END AS score
	FROM Passes p
	JOIN Teams t1 ON pass_from = t1.player_id
	JOIN Teams t2 ON pass_to = t2.player_id
)

SELECT team_name, half_number, SUM(score) AS dominance 
FROM (
	SELECT team_name, 1 AS half_number, score 
	FROM Scores
	WHERE Time <= 45 * 60
	
	UNION ALL
	
	SELECT team_name, 2 AS half_number, score 
	FROM Scores
	WHERE Time > 45 * 60
) AS t
GROUP BY team_name, half_number
ORDER BY team_name, half_number