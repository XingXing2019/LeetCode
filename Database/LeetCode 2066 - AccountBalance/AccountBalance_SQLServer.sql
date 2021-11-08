SELECT account_id, day, 
SUM(
	CASE [type] 
	WHEN 'Deposit' THEN amount 
	ELSE -amount END)
OVER (PARTITION BY account_id ORDER BY day) AS balance 
FROM Transactions
ORDER BY account_id