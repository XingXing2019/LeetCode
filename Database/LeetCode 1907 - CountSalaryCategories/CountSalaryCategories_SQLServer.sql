WITH CategoryAccounts AS (
	SELECT account_id, 
	CASE WHEN income < 20000 THEN 'Low Salary' WHEN income >= 20000 AND income <= 50000 THEN 'Average Salary' ELSE 'High Salary' END AS category 
	FROM Accounts
),

Category AS (
	SELECT 'Low Salary' AS category
	UNION ALL
	SELECT 'Average Salary' AS category
	UNION ALL
	SELECT 'High Salary' AS category
)

SELECT c.category, COUNT(account_id) AS accounts_count 
FROM Category c LEFT JOIN CategoryAccounts ca on c.category = ca.category
GROUP BY c.category