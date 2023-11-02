WITH ItemCount AS (
	SELECT u.seller_id, COUNT(DISTINCT i.item_id) AS num_items
	FROM Orders o
	JOIN Users u ON u.seller_id = o.seller_id
	JOIN Items i ON i.item_id = o.item_id
	WHERE i.item_brand <> u.favorite_brand
	GROUP BY u.seller_id
)

SELECT * FROM 
ItemCount
WHERE num_items = (SELECT TOP 1 num_items FROM ItemCount ORDER BY num_items DESC)
ORDER BY seller_id