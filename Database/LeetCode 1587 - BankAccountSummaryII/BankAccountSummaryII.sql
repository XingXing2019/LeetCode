SELECT u.name, SUM(t.amount) balance
FROM transactions t JOIN users u 
ON t.account = u.account
GROUP BY t.account
HAVING balance > 10000;