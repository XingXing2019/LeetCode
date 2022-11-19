WITH CustomerYearOrder AS (
	SELECT customer_id, YEAR(order_date) AS year, SUM(price) AS total_price
	FROM Orders
	GROUP BY customer_id, YEAR(order_date)
),

CustomerLastOrder AS (
	SELECT customer_id, MAX(year) AS last_year
	FROM CustomerYearOrder
	GROUP BY customer_id
),

InvalidCustomers AS (
	SELECT DISTINCT c1.customer_id
	FROM CustomerYearOrder c1
	LEFT JOIN CustomerYearOrder c2
	ON c1.customer_id = c2.customer_id
	AND c1.year + 1 = c2.year
	JOIN CustomerLastOrder c3
	ON c3.customer_id = c1.customer_id
	WHERE c1.total_price >= ISNULL(c2.total_price, 0)
	AND c1.year <> c3.last_year
)

SELECT DISTINCT customer_id
FROM Orders
WHERE customer_id NOT IN (SELECT customer_id FROM InvalidCustomers)