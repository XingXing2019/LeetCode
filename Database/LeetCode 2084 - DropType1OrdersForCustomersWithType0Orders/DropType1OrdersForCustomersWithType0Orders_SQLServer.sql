WITH HasZero AS (
	SELECT DISTINCT customer_id FROM Orders WHERE order_type = 0
)

SELECT order_id, o.customer_id, order_type
FROM Orders o
LEFT JOIN HasZero h
ON o.customer_id = h.customer_id
WHERE h.customer_id IS NULL
OR (h.customer_id IS NOT NULL AND order_type = 0)