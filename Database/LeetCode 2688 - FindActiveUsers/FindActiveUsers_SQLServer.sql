WITH DoubleOrders AS (
	SELECT user_id 
	FROM Users
	GROUP BY user_id, created_at
	HAVING COUNT(created_at) > 1
),

Orders AS (
	SELECT user_id, created_at, DENSE_RANK() OVER(PARTITION BY user_id ORDER BY created_at) AS orders
	FROM Users
	WHERE user_id NOT IN (SELECT * FROM DoubleOrders)
)

SELECT DISTINCT o1.user_id
FROM Orders o1
LEFT JOIN Orders o2
ON o1.user_id = o2.user_id AND o1.orders + 1 = o2.orders
WHERE DATEDIFF(DAY, o1.created_at, o2.created_at) <= 7

UNION

SELECT user_id 
FROM DoubleOrders