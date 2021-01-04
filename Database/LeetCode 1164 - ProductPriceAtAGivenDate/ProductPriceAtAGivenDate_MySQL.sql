SELECT A.product_id, CASE WHEN M.new_price IS NULL THEN 10 ELSE M.new_price END AS 'price'
FROM
(SELECT DISTINCT product_id FROM Products) A
LEFT JOIN
(SELECT product_id, new_price, 
RANK() OVER (PARTITION BY product_id ORDER BY change_date DESC) AS 'rnk'
FROM Products
WHERE change_date <= '2019-08-16') M
ON A.product_id = M.product_id
WHERE rnk = 1 OR rnk IS NULL;