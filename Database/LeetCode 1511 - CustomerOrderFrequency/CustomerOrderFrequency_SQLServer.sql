WITH JunJulOrders AS (SELECT * FROM orders WHERE LEFT(order_date, 7) in ('2020-06', '2020-07')),
spend AS (SELECT customer_id, quantity * price AS spend, LEFT(order_date, 7) AS month FROM JunJulOrders j LEFT JOIN product p ON j.product_id = p.product_id),
customerIds AS (SELECT * FROM (SELECT customer_id FROM spend GROUP BY customer_id, month HAVING SUM(spend) >= 100) AS t GROUP BY customer_id HAVING COUNT(*) = 2)

SELECT c2.customer_id, c2.name FROM customerIds c1 LEFT JOIN customers c2 ON c1.customer_id = c2.customer_id