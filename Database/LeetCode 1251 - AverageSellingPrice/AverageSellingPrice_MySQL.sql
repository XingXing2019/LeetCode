SELECT p.product_id, ROUND(SUM(p.price * s.units) / SUM(s.units), 2) AS average_price
FROM prices p RIGHT JOIN unitssold s
ON s.purchase_date BETWEEN p.start_date AND p.end_date AND p.product_id = s.product_id
GROUP BY p.product_id;