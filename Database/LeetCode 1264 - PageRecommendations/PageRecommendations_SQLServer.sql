WITH cte AS (SELECT * FROM Friendship 
WHERE user1_id = 1 OR user2_id = 1)
SELECT DISTINCT page_id AS recommended_page FROM
(SELECT DISTINCT user1_id FROM cte WHERE user1_id <> 1
UNION ALL
SELECT DISTINCT user2_id FROM cte WHERE user2_id <> 1) AS f LEFT JOIN
Likes l ON f.user1_id = l.user_id
WHERE page_id NOT IN (SELECT page_id FROM Likes WHERE user_id = 1)
AND page_id IS NOT NULL