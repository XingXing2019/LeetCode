WITH TransactionCount AS (
	SELECT transactions, COUNT(*) AS count FROM (
		SELECT v.user_id, v.visit_date, COUNT(t.transaction_date) AS transactions
		FROM Visits v
		LEFT JOIN Transactions t
		ON v.user_id = t.user_id AND v.visit_date = t.transaction_date
		GROUP BY v.user_id, v.visit_date
	) AS  t
	GROUP BY transactions	
),

MaxCount AS (
	SELECT MAX(transactions) AS max_count FROM TransactionCount
),

VisitCount AS (
	SELECT 0 as transactions_count
	UNION ALL
	SELECT transactions_count + 1 AS transactions_count
	FROM VisitCount
	WHERE transactions_count < (SELECT * FROM MaxCount)
)

SELECT transactions_count, ISNULL(count, 0) AS visits_count 
FROM VisitCount
LEFT JOIN TransactionCount
ON transactions_count = transactions