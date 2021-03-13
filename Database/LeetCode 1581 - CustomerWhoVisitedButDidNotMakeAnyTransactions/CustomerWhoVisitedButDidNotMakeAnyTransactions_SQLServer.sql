WITH VisitTransactions AS (SELECT customer_id, transaction_id FROM visits v LEFT JOIN transactions t ON v.visit_id = t.visit_id )
SELECT customer_id, COUNT(*) AS count_no_trans FROM VisitTransactions
WHERE transaction_id IS NULL
GROUP BY customer_id
