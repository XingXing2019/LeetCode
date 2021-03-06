SELECT ROUND(
		(SELECT COUNT(*) 
		FROM delivery 
		WHERE order_date = customer_pref_delivery_date) / (
		SELECT COUNT(*) 
		FROM delivery) *100, 2
	) AS immediate_percentage;