WITH Common AS (
	SELECT r1.user_id AS user1_id, r2.user_id AS user2_id, COUNT(DISTINCT r1.follower_id) AS Count
	FROM Relations r1 CROSS JOIN Relations r2
	WHERE r1.user_id < r2.user_id AND r1.follower_id = r2.follower_id
	GROUP BY r1.user_id, r2.user_id
)

SELECT user1_id, user2_id 
FROM Common WHERE Count = (SELECT MAX(Count) FROM Common)