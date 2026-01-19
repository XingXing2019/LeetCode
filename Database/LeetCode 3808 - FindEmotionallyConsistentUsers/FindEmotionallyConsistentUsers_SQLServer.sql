SELECT 
	t1.user_id AS user_id,
	t1.reaction AS dominant_reaction,
	ROUND(t1.count * 1.0 / t2.count, 2) AS reaction_ratio
FROM (
	SELECT user_id, reaction, COUNT(*) AS count FROM reactions
	GROUP BY user_id, reaction
) AS t1
JOIN (
	SELECT user_id, COUNT(*) AS count FROM reactions
	GROUP BY user_id
) AS t2 ON t1.user_id = t2.user_id
WHERE t1.count * 1.0 / t2.count >= 0.6
AND t2.count >= 5
ORDER BY reaction_ratio DESC, user_id