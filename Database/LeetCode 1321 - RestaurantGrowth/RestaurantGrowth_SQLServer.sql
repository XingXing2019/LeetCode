WITH cte AS (SELECT visited_on, SUM(amount) AS amount FROM Customer GROUP BY visited_on),
cte2 AS (SELECT visited_on, SUM(amount) OVER(ORDER BY visited_on) AS amount FROM cte)
SELECT c1.visited_on, c1.amount - ISNULL(c2.amount, 0) AS amount, ROUND((CONVERT(decimal, c1.amount) - ISNULL(c2.amount, 0)) / 7, 2) AS average_amount
FROM cte2 c1 left join cte2 c2 ON DATEDIFF(day, c2.visited_on, c1.visited_on) = 7
WHERE c1.visited_on > DATEADD(day, 5, (SELECT min(visited_on) FROM Customer))



