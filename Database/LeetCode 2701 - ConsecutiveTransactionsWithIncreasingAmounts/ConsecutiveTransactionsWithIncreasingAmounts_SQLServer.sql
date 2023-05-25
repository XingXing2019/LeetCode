WITH IncrementTransactions AS (
	SELECT t1.customer_id, t1.transaction_date
	FROM Transactions t1, Transactions t2
	WHERE t1.customer_id = t2.customer_id
	AND t1.amount < t2.amount
	AND DATEDIFF(DAY, t1.transaction_date, t2.transaction_date) = 1
),

TransactionRows AS (
	SELECT customer_id, transaction_date, ROW_NUMBER() OVER(PARTITION BY customer_id ORDER BY transaction_date) AS rn
	FROM IncrementTransactions
),

BaseDate AS (
	SELECT customer_id, transaction_date, rn, DATEADD(DAY, -rn, transaction_date) AS base_date
	FROM TransactionRows
)

SELECT customer_id, consecutive_start, DATEADD(DAY, days, consecutive_start) AS consecutive_end
FROM (
	SELECT customer_id, base_date, MIN(transaction_date) AS consecutive_start, COUNT(*) AS days
	FROM BaseDate
	GROUP BY customer_id, base_date
	HAVING COUNT(*) >= 2
) AS t
ORDER BY customer_id