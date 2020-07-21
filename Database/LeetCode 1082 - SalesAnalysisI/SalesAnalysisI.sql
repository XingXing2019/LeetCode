SELECT seller_id
FROM sales
GROUP BY seller_id
HAVING SUM(price) = 
(
	SELECT SUM(s.price)
	FROM sales s
	GROUP BY s.seller_id
	ORDER BY SUM(s.price) DESC
	LIMIT 1
);