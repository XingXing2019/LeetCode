WITH cte AS (SELECT *, RANK() OVER(PARTITION BY product_id ORDER BY order_date DESC) AS rank FROM orders)
SELECT product_name, p.product_id, order_id, order_date
FROM cte c LEFT JOIN products p on c.product_id = p.product_id
WHERE rank = 1
ORDER BY p.product_name, p.product_id, order_id
