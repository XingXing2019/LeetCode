WITH max_price AS (
	SELECT *, RANK() OVER(PARTITION BY store_id ORDER BY price DESC) AS price_rank
	FROM inventory
),

min_price AS (
	SELECT *, RANK() OVER(PARTITION BY store_id ORDER BY price) AS price_rank
	FROM inventory
)

SELECT s.store_id, store_name, location, most_exp_product, cheapest_product, imbalance_ratio 
FROM (
	SELECT p1.store_id, p1.product_name AS most_exp_product, p2.product_name AS cheapest_product, ROUND(1.0 * p2.quantity / p1.quantity, 2) AS imbalance_ratio
	FROM max_price p1
	LEFT JOIN min_price p2 ON p1.store_id = p2.store_id
	WHERE p1.price_rank = 1
	AND p2.price_rank = 1
	AND p1.store_id IN (
		SELECT store_id FROM inventory
		GROUP BY store_id
		HAVING COUNT(DISTINCT product_name) >= 3
	)
	AND p1.quantity < p2.quantity
) AS t
JOIN stores s ON s.store_id = t.store_id
ORDER BY imbalance_ratio DESC, store_name