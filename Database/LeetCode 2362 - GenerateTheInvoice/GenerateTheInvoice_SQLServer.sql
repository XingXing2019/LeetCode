WITH TotalPrice AS (
	SELECT invoice_id, SUM(quantity * price) AS total_price
	FROM Purchases p1
	JOIN Products p2
	ON p1.product_id = p2.product_id
	GROUP BY invoice_id
),

InvoiceId AS (
	SELECT MIN(invoice_id) AS invoice_id
	FROM TotalPrice
	WHERE total_price = (SELECT MAX(total_price) FROM TotalPrice)
)

SELECT p1.product_id, quantity, (price * quantity) AS price
FROM Purchases p1
JOIN Products p2 ON p1.product_id = p2.product_id
WHERE invoice_id = (SELECT * FROM InvoiceId)