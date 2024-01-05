WITH Fridays AS (
	SELECT 1 AS week_of_month, '2023-11-03' AS friday
	UNION
	SELECT 2 AS week_of_month, '2023-11-10' AS friday
	UNION
	SELECT 3 AS week_of_month, '2023-11-17' AS friday
	UNION
	SELECT 4 AS week_of_month, '2023-11-24' AS friday
)

SELECT week_of_month, friday AS purchase_date, ISNULL(total_amount, 0) AS total_amount
FROM Fridays 
LEFT JOIN (
	SELECT purchase_date, SUM(amount_spend) AS total_amount
	FROM Purchases
	WHERE purchase_date IN (SELECT friday FROM Fridays)
	GROUP BY purchase_date
) t ON friday = t.purchase_date;