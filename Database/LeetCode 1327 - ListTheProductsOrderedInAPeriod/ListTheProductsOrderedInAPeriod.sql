SELECT p.product_name, SUM(o.unit) AS unit
FROM orders o LEFT JOIN products p
ON o.product_id = p.product_id
WHERE o.order_date BETWEEN '2020-02-01' AND '2020-02-29'
GROUP BY p.product_id
HAVING unit >= 100;