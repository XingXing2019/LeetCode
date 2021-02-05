WITH cte AS (SELECT *, RANK() OVER(PARTITION BY customer_id ORDER BY order_date DESC) AS rank FROM orders)
SELECT c2.name AS customer_name, c2.customer_id, c1.order_id, c1.order_date FROM cte c1 LEFT JOIN customers c2 ON c1.customer_id = c2.customer_id where c1.rank < 4
order by c2.name, c2.customer_id, order_date desc;