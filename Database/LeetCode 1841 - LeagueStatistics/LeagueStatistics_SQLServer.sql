WITH Score AS (SELECT home_team_id AS Team, 
CASE WHEN home_team_goals = away_team_goals THEN 1 
WHEN home_team_goals > away_team_goals THEN 3
ELSE 0 END AS Score, home_team_goals AS GoalFor, away_team_goals AS GoalAgainst FROM Matches
UNION ALL 
SELECT away_team_id AS Team, 
CASE WHEN home_team_goals = away_team_goals THEN 1 
WHEN home_team_goals < away_team_goals THEN 3
ELSE 0 END AS Score, away_team_goals AS GoalFor, home_team_goals AS GoalAgainst FROM Matches)

SELECT team_name, COUNT(*) AS matches_played, SUM(Score) AS points, SUM(GoalFor) AS goal_for, 
SUM(GoalAgainst) AS goal_against, SUM(GoalFor) - SUM(GoalAgainst) AS goal_diff
FROM Score LEFT JOIN Teams ON Team = team_id
GROUP BY team_name 
ORDER BY points DESC, goal_diff DESC, team_name