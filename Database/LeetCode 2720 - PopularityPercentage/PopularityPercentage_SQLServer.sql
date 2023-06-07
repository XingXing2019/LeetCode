WITH Users AS (
	SELECT user1, user2 FROM Friends
	UNION
	SELECT user2, user1 FROM Friends 
)

SELECT 
	user1, 
	ROUND(CONVERT(FLOAT, COUNT(user2)) / (SELECT COUNT(DISTINCT user1) FROM Users) * 100, 2) AS percentage_popularity
FROM Users
GROUP BY user1