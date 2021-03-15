WITH trimed AS (SELECT product_id, SUM(rest) AS rest, SUM(paid) AS paid, SUM(canceled) AS canceled, SUM(refunded) AS refunded FROM invoice GROUP BY product_id)
SELECT name, rest, paid, canceled, refunded 
FROM trimed t LEFT JOIN product p ON t.product_id = p.product_id
ORDER BY name