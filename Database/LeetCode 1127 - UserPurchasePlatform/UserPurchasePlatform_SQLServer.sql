WITH mobile AS (
	SELECT user_id, 'mobile' AS platform, spend_date, SUM(amount) AS total_amount, COUNT(DISTINCT user_id) AS total_users
	FROM Spending
	GROUP BY user_id, spend_date
	HAVING COUNT(DISTINCT platform) = 1
	AND MIN(platform) = 'mobile'
),
desktop AS (
	SELECT user_id, 'desktop' AS platform, spend_date, SUM(amount) AS total_amount, COUNT(DISTINCT user_id) AS total_users
	FROM Spending
	GROUP BY user_id, spend_date
	HAVING COUNT(DISTINCT platform) = 1
	AND MIN(platform) = 'desktop'
),
both AS (
	SELECT user_id, 'both' AS platform, spend_date, SUM(amount) AS total_amount, COUNT(DISTINCT user_id) AS total_users
	FROM Spending
	GROUP BY user_id, spend_date
	HAVING COUNT(DISTINCT platform) = 2
),
date AS (
	SELECT DISTINCT spend_date FROM Spending
),
total AS (
	SELECT d.spend_date, ISNULL(platform, 'mobile') AS platform, ISNULL(total_amount, 0) AS total_amount, ISNULL(total_users, 0) AS total_users
	FROM date d LEFT JOIN mobile m
	ON d.spend_date = m.spend_date
	UNION ALL
	SELECT d.spend_date, ISNULL(platform, 'desktop') AS platform, ISNULL(total_amount, 0) AS total_amount, ISNULL(total_users, 0) AS total_users
	FROM date d LEFT JOIN desktop dt
	ON d.spend_date = dt.spend_date
	UNION ALL
	SELECT d.spend_date, ISNULL(platform, 'both') AS platform, ISNULL(total_amount, 0) AS total_amount, ISNULL(total_users, 0) AS total_users
	FROM date d LEFT JOIN both b
	ON d.spend_date = b.spend_date
)

SELECT spend_date, platform, SUM(total_amount) AS total_amount, SUM(total_users) AS total_users 
FROM total
GROUP BY spend_date, platform
ORDER BY spend_date