SELECT p.product_id, p.price * 1.0 * (100 - ISNULL(d.discount, 0)) / 100 AS final_price, p.category AS category
FROM Products p
LEFT JOIN Discounts d ON p.category = d.category
ORDER BY p.product_id ASC