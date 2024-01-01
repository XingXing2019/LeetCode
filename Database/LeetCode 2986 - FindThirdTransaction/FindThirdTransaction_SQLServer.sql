WITH DateRank AS (
	SELECT *, RANK() OVER(PARTITION BY user_id ORDER BY transaction_date) AS date_rank
	FROM Transactions
)

SELECT d3.user_id, d3.spend AS third_transaction_spend, d3.transaction_date AS third_transaction_date
FROM DateRank d1
JOIN DateRank d2 ON d1.user_id = d2.user_id AND d1.date_rank + 1 = d2.date_rank
JOIN DateRank d3 ON d2.user_id = d3.user_id AND d2.date_rank + 1 = d3.date_rank
WHERE d1.spend < d3.spend AND d2.spend < d3.spend
AND d3.date_rank = 3