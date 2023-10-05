SELECT (minute - 1) / 6 + 1 AS interval_no, SUM(order_count) AS total_orders
FROM Orders
GROUP BY (minute - 1) / 6