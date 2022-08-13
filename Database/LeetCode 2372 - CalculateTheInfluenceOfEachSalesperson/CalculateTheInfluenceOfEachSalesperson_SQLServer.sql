SELECT s.*, ISNULL(TotalPrice.total, 0) AS total
FROM Salesperson s
LEFT JOIN (
	SELECT c.salesperson_id, SUM(s.price) AS total
	FROM Sales s
	JOIN Customer c ON s.customer_id = c.customer_id
	GROUP BY c.salesperson_id
) AS TotalPrice
ON s.salesperson_id = TotalPrice.salesperson_id