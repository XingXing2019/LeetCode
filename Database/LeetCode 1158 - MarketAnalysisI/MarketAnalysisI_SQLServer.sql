SELECT u.user_id AS buyer_id, u.join_date, ISNULL(t.count, 0) AS orders_in_2019
FROM users u LEFT JOIN 
(SELECT o.buyer_id, COUNT(o.item_id) count
FROM orders o 
WHERE order_date BETWEEN '2019-01-01' AND '2019-12-31'
GROUP BY o.buyer_id) AS t
ON u.user_id = t.buyer_id
