WITH SameSong AS (SELECT l1.user_id AS user1, l2.user_id AS user2
FROM Listens l1
CROSS JOIN Listens l2
WHERE l1.user_id <> l2.user_id AND l1.song_id = l2.song_id AND l1.day = l2.day
GROUP BY l1.user_id, l2.user_id, l1.day
HAVING COUNT(DISTINCT l1.song_id) >= 3),

Friends AS (
	SELECT user1_id AS user1, user2_id AS user2 FROM Friendship
	UNION ALL
	SELECT user2_id AS user1, user1_id AS user2 FROM Friendship
)

SELECT s.user1 AS user_id, s.user2 AS recommended_id 
FROM SameSong s
LEFT JOIN Friends f
ON s.user1 = f.user1 AND s.user2 = f.user2
WHERE f.user1 IS NULL AND f.user2 IS NULL
