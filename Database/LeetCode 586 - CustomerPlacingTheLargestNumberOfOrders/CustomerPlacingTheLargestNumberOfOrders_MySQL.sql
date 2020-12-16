SELECT o.customer_number
FROM orders o
GROUP BY o.customer_number
ORDER BY COUNT(*) DESC	
LIMIT 1;