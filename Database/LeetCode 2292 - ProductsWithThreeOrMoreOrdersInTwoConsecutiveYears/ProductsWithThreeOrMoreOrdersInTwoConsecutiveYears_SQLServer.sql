WITH OrderInYear AS (
	SELECT product_id, YEAR(purchase_date) AS year
	FROM Orders
	GROUP BY product_id, YEAR(purchase_date) 
	HAVING COUNT(DISTINCT order_id) >= 3
)

SELECT DISTINCT o1.product_id
FROM OrderInYear o1 JOIN OrderInYear o2
ON o1.product_id = o2.product_id
AND o1.year - o2.year = 1