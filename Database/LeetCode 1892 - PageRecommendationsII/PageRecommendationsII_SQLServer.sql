WITH Friends AS (SELECT user1_id AS user_id, user2_id AS friend FROM Friendship
UNION ALL
SELECT user2_id AS user_id, user1_id AS friend FROM Friendship)

SELECT f.user_id, l1.page_id, COUNT(DISTINCT f.friend) AS friends_likes 
FROM Friends f 
LEFT JOIN Likes l1 ON f.friend = l1.user_id 
LEFT JOIN Likes l2 ON f.user_id = l2.user_id AND l1.page_id = l2.page_id
WHERE l2.page_id IS NULL
GROUP BY f.user_id, l1.page_id