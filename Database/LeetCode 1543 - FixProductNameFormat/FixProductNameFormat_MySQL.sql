SELECT f.product_name, f.sale_date, COUNT(*) total
FROM ( 
	SELECT TRIM(LOWER(s.product_name)) product_name, DATE_FORMAT(s.sale_date, '%Y-%m') sale_date
	FROM sales s
) f
GROUP BY f.sale_date, f.product_name
ORDER BY product_name ASC, sale_date ASC;