WITH ProductPair AS (
	SELECT 
		p1.user_id, 
		p1.product_id AS product1_id,
		p2.product_id AS product2_id, 
		CONVERT(VARCHAR, p1.product_id) + '-' + CONVERT(VARCHAR, p2.product_id) AS product_pair
	FROM ProductPurchases p1
	JOIN ProductPurchases p2 ON p1.user_id = p2.user_id AND p1.product_id < p2.product_id
)

SELECT
	p.product1_id,
	p.product2_id, 
	pi1.category AS product1_category,
	pi2.category AS product2_category,
	COUNT(*) AS customer_count
FROM ProductPair p
JOIN ProductInfo pi1 ON pi1.product_id = p.product1_id
JOIN ProductInfo pi2 ON pi2.product_id = p.product2_id
WHERE p.product_pair IN (
	SELECT product_pair
	FROM ProductPair
	GROUP BY product_pair
	HAVING COUNT(user_id) >= 3
)
GROUP BY p.product1_id, p.product2_id, pi1.category, pi2.category 
ORDER BY COUNT(*) DESC, p.product1_id, p.product2_id