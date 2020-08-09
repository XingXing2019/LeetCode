SELECT `name`
FROM salesperson
WHERE `name` NOT IN (
	SELECT s1.name
	FROM orders o1
	JOIN company c1 ON o1.com_id = c1.com_id
	JOIN salesperson s1 ON o1.sales_id = s1.sales_id
	WHERE c1.name = 'RED'
);