WITH Incomes AS (SELECT CONVERT(FLOAT, YEAR(day)) + CONVERT(float, MONTH(day)) / 10 AS Date, account_id, SUM(amount) AS Income
FROM transactions WHERE type = 'Creditor'
GROUP BY CONVERT(FLOAT, YEAR(day)) + CONVERT(float, MONTH(day)) / 10, account_id),

CTE AS (SELECT Date, a.account_id FROM Incomes i LEFT JOIN accounts a ON i.account_id = a.account_id
WHERE i.Income > a.max_income)

SELECT DISTINCT(c1.account_id) FROM CTE c1 JOIN CTE c2 ON c1.account_id = c2.account_id 
WHERE ROUND(c2.Date - c1.Date, 1) = 0.1
