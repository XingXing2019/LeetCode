WITH FebPost AS (
	SELECT * FROM Posts WHERE post_date BETWEEN '2024-02-01' AND '2024-02-28'
),

AvgWeeklyPost AS (
	SELECT user_id, COUNT(post_id) / 4.0 AS avg_weekly_posts FROM FebPost
	GROUP BY user_id
),

MaxPost AS (
	SELECT user_id, MAX(count) AS max_7day_posts FROM (
		SELECT user_id, post_date, COUNT(post_id) AS count FROM (
			SELECT p1.*
			FROM FebPost p1
			LEFT JOIN FebPost p2 ON p1.user_id = p2.user_id
			WHERE DATEDIFF(DAY, p1.post_date, p2.post_date) < 7
			AND DATEDIFF(DAY, p1.post_date, p2.post_date)>= 0
		) AS t
		GROUP BY user_id, post_date, post_id
	) AS t
	GROUP BY user_id
)

SELECT a.user_id, max_7day_posts, avg_weekly_posts 
FROM AvgWeeklyPost a
JOIN MaxPost m ON a.user_id = m.user_id
WHERE max_7day_posts >= 2 * avg_weekly_posts
ORDER BY a.user_id