WITH Trimed AS (SELECT TRIM(LOWER(product_name)) AS product_name, LEFT(sale_date, 7) AS sale_date FROM sales)

SELECT product_name, sale_date, COUNT(*) AS total FROM Trimed GROUP BY product_name, sale_date
ORDER BY product_name, sale_date
