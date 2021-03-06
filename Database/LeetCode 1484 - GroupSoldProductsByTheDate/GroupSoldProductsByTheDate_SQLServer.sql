SELECT sell_date, COUNT(product) AS num_sold,
STRING_AGG(product,',') WITHIN GROUP (ORDER BY product) AS products FROM
(SELECT DISTINCT sell_date,product FROM Activities) Act GROUP BY sell_date