WITH AllFriends AS (
	SELECT user_id1, user_id2 FROM Friends
	UNION
	SELECT user_id2, user_id1 FROM Friends
),

HasMutual AS (
	SELECT CONVERT(VARCHAR, f1.user_id1) + '-' + CONVERT(VARCHAR, f2.user_id2) AS ids FROM AllFriends f1
	JOIN AllFriends f2 ON f1.user_id2 = f2.user_id1
	WHERE f1.user_id1 <> f2.user_id2
)

SELECT * FROM Friends
WHERE CONVERT(VARCHAR, user_id1) + '-' + CONVERT(VARCHAR, user_id2) NOT IN (
	SELECT * FROM HasMutual
)
ORDER BY user_id1, user_id2