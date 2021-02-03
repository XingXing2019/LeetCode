DECLARE @start INT = 1;
DECLARE @end INT = (SELECT MAX(customer_id) FROM customers);
WITH recursion AS (
	SELECT @start AS ids
	UNION ALL
	SELECT ids + 1 FROM recursion WHERE ids + 1 <= @end
)
select * from recursion WHERE ids NOT IN (SELECT customer_id FROM customers);