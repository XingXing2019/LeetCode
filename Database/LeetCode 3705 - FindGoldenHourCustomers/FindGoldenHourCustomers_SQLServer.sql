WITH order_info AS (
	SELECT order_id, customer_id, CAST(order_timestamp AS TIME) AS order_time, order_rating
	FROM restaurant_orders
)

SELECT 
	customer_id,
	total_orders,
	ROUND(peak_order * 1.0 / total_orders * 100, 0) AS peak_hour_percentage,
	average_rating
FROM (
	SELECT 
		customer_id, 
		COUNT(order_id) AS total_orders,
		SUM(IIF(order_time BETWEEN '11:00:00' AND '14:00:00' OR order_time BETWEEN '18:00:00' AND '21:00:00', 1, 0)) AS peak_order,
		ROUND(AVG(order_rating * 1.0), 2) AS average_rating,
		SUM(IIF(order_rating IS NULL, 0, 1)) AS rating_count
	FROM order_info
	GROUP BY customer_id
) AS t
WHERE total_orders>= 3
AND peak_order * 1.0 / total_orders >= 0.6
AND average_rating >= 4
AND rating_count * 1.0 / total_orders >= 0.5
ORDER BY average_rating DESC, customer_id DESC
