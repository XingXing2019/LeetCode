WITH MostFrequently AS (
	SELECT customer_id, category AS top_category, RANK() OVER(PARTITION BY customer_id ORDER BY count DESC, date DESC) AS rank 
	FROM (
		SELECT customer_id, category, COUNT(transaction_id) AS count, MAX(transaction_date) AS date
		FROM Transactions t
		JOIN Products p ON t.product_id = p.product_id
		GROUP BY customer_id, category
	) AS t
)

SELECT t.customer_id, total_amount, transaction_count, unique_categories, avg_transaction_amount, top_category, loyalty_score 
FROM MostFrequently m
JOIN (
	SELECT 
		customer_id, 
		SUM(amount) AS total_amount, 
		COUNT(transaction_id) AS transaction_count,
		COUNT(DISTINCT category) AS unique_categories,
		ROUND(SUM(amount) / COUNT(transaction_id), 2) AS avg_transaction_amount,
		ROUND(COUNT(transaction_id) * 10 + (SUM(amount) / 100), 2) AS loyalty_score 
	FROM Transactions t
	JOIN Products p ON t.product_id = p.product_id
	GROUP BY customer_id
) AS t ON t.customer_id = m.customer_id
WHERE m.rank = 1
ORDER BY loyalty_score DESC, t.customer_id 