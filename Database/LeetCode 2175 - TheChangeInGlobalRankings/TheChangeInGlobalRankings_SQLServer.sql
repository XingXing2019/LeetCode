WITH Old_Rank AS (
	SELECT *, RANK() OVER(ORDER BY points DESC, name) AS old_rank	
	FROM TeamPoints
),

New_Rank AS (
	SELECT t.*, RANK() OVER(ORDER BY t.points + ISNULL(p.points_change, 0) DESC, name) AS new_rank
	FROM TeamPoints t LEFT JOIN PointsChange p
	ON t.team_id = p.team_id
)

SELECT o.team_id, o.name, o.old_rank - n.new_rank AS rank_diff
FROM Old_Rank o 
JOIN New_Rank n
ON o.team_id = n.team_id