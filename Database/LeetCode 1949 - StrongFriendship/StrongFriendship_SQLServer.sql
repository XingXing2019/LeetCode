WITH Friends AS (
	SELECT user1_id AS user1_id, user2_id AS user2_id FROM Friendship
	UNION ALL
	SELECT user2_id AS user1_id, user1_id AS user2_id FROM Friendship
),
CommonFriends AS (
	SELECT f1.user1_id, f2.user2_id AS user1Friend, f1.user2_id, f3.user2_id AS user2Friend
	FROM Friends f1
	JOIN Friends f2 ON f1.user1_id = f2.user1_id
	JOIN Friends f3 ON f1.user2_id = f3.user1_id
)

SELECT user1_id, user2_id, COUNT(*) AS common_friend 
FROM CommonFriends
WHERE user1Friend = user2Friend AND user1_id < user2_id
GROUP BY user1_id, user2_id
HAVING COUNT(*) >= 3