WITH RECURSIVE recursion AS (
	SELECT 1 AS ids
    UNION ALL
    SELECT ids + 1 FROM recursion WHERE ids + 1 <= (SELECT MAX(customer_id) FROM customers)
)
SELECT * FROM recursion WHERE ids NOT IN (SELECT customer_id FROM Customers);
