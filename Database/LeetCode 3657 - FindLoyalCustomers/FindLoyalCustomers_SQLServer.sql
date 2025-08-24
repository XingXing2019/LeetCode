SELECT customer_id
FROM customer_transactions
GROUP BY customer_id
HAVING COUNT(transaction_id) >= 3
AND DATEDIFF(DAY, MIN(transaction_date), MAX(transaction_date)) >= 30
AND SUM(IIF(transaction_type = 'refund', 1, 0)) * 1.0 / COUNT(transaction_id) < 0.2
ORDER BY customer_id