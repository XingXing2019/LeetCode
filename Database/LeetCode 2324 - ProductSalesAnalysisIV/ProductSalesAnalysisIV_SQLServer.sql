WITH TotalSpending AS (
	SELECT user_id, p.product_id, total_quantity * p.price AS total_spending 
	FROM (
		SELECT user_id, product_id, SUM(quantity) AS total_quantity 
		FROM Sales
		GROUP BY user_id, product_id
	) AS TotalQuantity
	JOIN Product p
	ON p.product_id = TotalQuantity.product_id

)

SELECT t.user_id, t.product_id 
FROM TotalSpending t
JOIN (
	SELECT user_id, MAX(total_spending) AS max_spending 
	FROM TotalSpending
	GROUP BY user_id
) AS MaxSpending
ON t.user_id = MaxSpending.user_id
AND t.total_spending = MaxSpending.max_spending
ORDER BY t.user_id