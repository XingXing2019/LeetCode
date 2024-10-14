select *, rank() over(partition by season_id order by t.points desc, t.goal_difference desc, team_name) as position
from (
	select season_id, team_id, team_name, wins * 3 + draws as points, goals_for - goals_against as goal_difference
    from SeasonStats
) as t
 order by season_id, position, team_name