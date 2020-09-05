SELECT SUBSTR(order_date,1,7) AS MONTH, COUNT(DISTINCT order_id) AS order_count, COUNT(DISTINCT customer_id) AS customer_count
FROM orders o
WHERE invoice > 20
GROUP BY 1;