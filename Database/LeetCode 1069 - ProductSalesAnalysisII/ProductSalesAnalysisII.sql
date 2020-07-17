SELECT p.product_id, SUM(quantity) AS total_quantity 
FROM sales s JOIN product p
ON s.product_id = p.product_id
GROUP BY p.product_id;