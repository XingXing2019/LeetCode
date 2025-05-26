WITH product_sales AS (
	SELECT quantity, price, category, (MONTH(sale_date) + IIF(MONTH(sale_date) = 12, 0, 12)) / 3 AS month
	FROM Sales s JOIN Products p ON s.product_id = p.product_id
),

season_sales AS (
	SELECT CASE
		WHEN month = 4 THEN 'Winter'
		WHEN month = 5 THEN 'Spring'
		WHEN month = 6 THEN 'Summer'
		ELSE 'Fall'
	END AS season, category, SUM(quantity) AS total_quantity, SUM(price * quantity) AS total_revenue
	FROM product_sales
	GROUP BY month, category
)

SELECT season, category, total_quantity, total_revenue 
FROM (
	SELECT *, RANK() OVER(PARTITION BY season ORDER BY total_quantity DESC, total_revenue DESC) AS rank
	FROM season_sales
) AS t
WHERE rank = 1
ORDER BY season