SELECT (DATEPART(DAY, purchase_date) - 1) / 7 + 1 AS week_of_month, purchase_date, SUM(amount_spend) AS total_amount
FROM Purchases
WHERE purchase_date BETWEEN '2023-11-01' AND '2023-11-30'
AND DATEPART(DW, purchase_date) = 6
GROUP BY purchase_date
ORDER BY purchase_date