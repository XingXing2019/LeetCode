WITH cte1 AS (SELECT LEFT(trans_date, 7) month, country, count(*) count, sum(amount) amount FROM transactions WHERE state = 'approved' GROUP BY LEFT(trans_date, 7), country),
cte2 AS (SELECT LEFT(c.trans_date, 7) month, country, count(*) count, sum(amount) amount FROM chargebacks c LEFT JOIN transactions t ON c.trans_id = t.id GROUP BY LEFT(c.trans_date, 7), country)
SELECT ISNULL(c1.month, c2.month) AS month, ISNULL(c1.country, c2.country) AS country, ISNULL(c1.count, 0) AS approved_count, 
ISNULL(c1.amount, 0) AS approved_amount, ISNULL(c2.count, 0) AS chargeback_count, ISNULL(c2.amount, 0) AS chargeback_amount
FROM cte1 c1 FULL JOIN cte2 c2 on c1.month = c2.month AND c1.country = c2.country