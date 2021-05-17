DECLARE @MaxAvg FLOAT;
SELECT @MaxAvg = (SELECT MAX(Avg) FROM (SELECT AVG(CONVERT(FLOAT, quantity)) AS Avg FROM OrdersDetails GROUP BY order_id) AS Temp);

SELECT order_id FROM OrdersDetails GROUP BY order_id HAVING MAX(quantity) > @MaxAvg