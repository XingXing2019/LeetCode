WITH cte AS (SELECT customer_id, MIN(order_date) AS first FROM delivery GROUP BY customer_id)
SELECT ROUND(CONVERT(decimal, COUNT(*)) / (SELECT COUNT(*) FROM cte) * 100, 2) AS immediate_percentage 
FROM cte c INNER JOIN delivery d
ON d.customer_pref_delivery_date = c.first AND d.customer_id = c.customer_id

