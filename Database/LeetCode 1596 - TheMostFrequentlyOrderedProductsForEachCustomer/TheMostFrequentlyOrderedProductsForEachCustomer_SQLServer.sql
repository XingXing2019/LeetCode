WITH cte AS (SELECT customer_id, product_id, COUNT(product_id) count FROM orders GROUP BY customer_id, product_id)
SELECT customer_id, p.product_id, product_name FROM (SELECT *, RANK() OVER(PARTITION BY customer_id ORDER BY count DESC) AS rank FROM cte) AS t 
LEFT JOIN products p ON p.product_id = t.product_id
WHERE rank = 1