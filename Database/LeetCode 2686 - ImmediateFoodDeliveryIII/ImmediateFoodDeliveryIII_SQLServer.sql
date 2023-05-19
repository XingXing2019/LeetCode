SELECT 
	order_date, 
	ROUND(CONVERT(FLOAT, SUM(
		CASE 
			WHEN order_date = customer_pref_delivery_date THEN 1
			ELSE 0
		END 
	)) / COUNT(delivery_id) * 100, 2) AS immediate_percentage
FROM Delivery
GROUP BY order_date