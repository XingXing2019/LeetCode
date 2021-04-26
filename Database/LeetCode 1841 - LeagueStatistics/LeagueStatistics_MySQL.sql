with score as (select home_team_id as Team, home_team_goals as GoalFor, away_team_goals as GoalAgainst,
case when home_team_goals > away_team_goals then 3
when home_team_goals = away_team_goals then 1
else 0 end as points from matches
union all
select away_team_id as Team, away_team_goals as GoalFor, home_team_goals as GoalAgainst,
case when home_team_goals < away_team_goals then 3
when home_team_goals = away_team_goals then 1
else 0 end as points from matches)

select team_name, count(*) as matches_played, sum(points) as points, sum(GoalFor) as goal_for, sum(GoalAgainst) as goal_against,
sum(GoalFor) - sum(GoalAgainst) as goal_diff
from score left join teams on Team = team_id
group by team_name
order by points desc, goal_diff desc, team_name