WITH firstScore AS (SELECT first_player AS player, SUM(first_score) score FROM matches GROUP BY first_player),
secondScore AS (SELECT second_player AS player, SUM(second_score) score FROM matches GROUP BY second_player),
score AS (SELECT p.player_id, group_id, (ISNULL(f.score, 0) + ISNULL(s.score, 0)) AS score 
FROM players p LEFT JOIN firstScore f ON p.player_id = f.player LEFT JOIN secondScore s ON p.player_id = s.player),
scoreRank AS (SELECT *, RANK() OVER(PARTITION BY group_id ORDER BY score DESC, player_id) AS scoreRank FROM score)

SELECT group_id, player_id FROM scoreRank WHERE scoreRank = 1