WITH saleRank AS (SELECT *, RANK() OVER(PARTITION BY seller_id ORDER BY order_date) AS saleRank FROM orders),
sales AS (SELECT seller_id, item_brand FROM saleRank s LEFT JOIN items i ON s.item_id = i.item_id WHERE saleRank = 2)

SELECT user_id AS seller_id, 
CASE WHEN favorite_brand = item_brand THEN 'yes' ELSE 'no' END AS '2nd_item_fav_brand' 
FROM users u LEFT JOIN sales s ON u.user_id = s.seller_id