WITH balance AS (SELECT account, SUM(amount) AS balance FROM Transactions GROUP BY account HAVING SUM(amount) > 10000)
SELECT name, balance FROM balance b LEFT JOIN users u ON b.account = u.account