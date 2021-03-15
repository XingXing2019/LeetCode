SELECT p.name, SUM(i.rest) rest, SUM(i.paid) paid, SUM(i.canceled) canceled, SUM(i.refunded) refunded 
FROM invoice i LEFT JOIN product p
ON i.product_id = p.product_id
GROUP BY p.product_id
ORDER BY p.name;