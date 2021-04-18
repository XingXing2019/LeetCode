WITH DateMaxAmount AS (SELECT CAST(day AS DATE) as date, MAX(amount) as amount FROM Transactions t GROUP BY CAST(day AS DATE))
SELECT transaction_id FROM Transactions t join DateMaxAmount d ON CAST(t.day AS DATE) = d.date AND t.amount = d.amount
ORDER BY transaction_id
