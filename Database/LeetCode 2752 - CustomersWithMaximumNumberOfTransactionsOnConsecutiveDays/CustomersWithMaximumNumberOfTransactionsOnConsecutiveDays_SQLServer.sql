WITH StartDate AS (
	SELECT customer_id, DATEADD(DAY, -rows, transaction_date) AS start_date FROM (
		SELECT customer_id, transaction_date, ROW_NUMBER() OVER(PARTITION BY customer_id ORDER BY transaction_date) AS rows
		FROM (
			SELECT DISTINCT customer_id, transaction_date 
			FROM Transactions t1
		) AS t
	) AS rows
	
),

TransCount AS (
	SELECT customer_id, start_date, COUNT(*) AS counts
	FROM StartDate
	GROUP BY customer_id, start_date
)

SELECT customer_id 
FROM TransCount
WHERE counts = (SELECT MAX(counts) FROM TransCount)
ORDER BY customer_id