SELECT * FROM customers
WHERE customer_id IN (SELECT customer_id FROM orders WHERE product_name = 'A')
AND customer_id IN (SELECT customer_id FROM orders WHERE product_name = 'B')
AND customer_id NOT IN (SELECT customer_id FROM orders WHERE product_name = 'C')