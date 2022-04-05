WITH MatchWords AS (
	SELECT DISTINCT post_id, topic_id FROM Posts
	LEFT JOIN Keywords
	ON CONCAT(' ', content, ' ') LIKE CONCAT('% ', word, ' %')
)

SELECT post_id, ISNULL(STRING_AGG(topic_id, ',') WITHIN GROUP (ORDER BY topic_id), 'Ambiguous!') AS topic
FROM MatchWords
GROUP BY post_id
