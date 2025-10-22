WITH subscription_events_rank AS (
	SELECT 
		*, 
		RANK() OVER(PARTITION BY user_id ORDER BY event_date DESC) AS rank,
		MAX(monthly_amount) OVER(PARTITION BY user_id) AS max
	FROM subscription_events
	WHERE user_id IN (
		SELECT user_id FROM subscription_events
		WHERE event_type = 'downgrade'
	)
),

current_revenue AS (
	SELECT monthly_amount / max AS revenue, *
	FROM subscription_events_rank
	WHERE rank = 1
),

users AS (
	SELECT user_id, DATEDIFF(DAY, MIN(event_date), MAX(event_date)) AS days_as_subscriber
	FROM subscription_events_rank
	WHERE user_id NOT IN (
		SELECT user_id FROM subscription_events_rank
		WHERE rank = 1 AND event_type = 'cancel'
	)
	AND user_id IN (
		SELECT user_id FROM current_revenue
		WHERE revenue < 0.5
	)
	GROUP BY user_id
	HAVING DATEDIFF(DAY, MIN(event_date), MAX(event_date)) >= 60
)

SELECT 
	r.user_id, 
	plan_name AS current_plan,
	monthly_amount AS current_monthly_amount,
	max AS max_historical_amount,
	days_as_subscriber
FROM current_revenue r
JOIN users u ON u.user_id = r.user_id
ORDER BY days_as_subscriber DESC, r.user_id