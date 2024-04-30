WITH Fridays AS (
	SELECT '2023-11-03' AS friday, 1 as week_of_month
	UNION
	SELECT '2023-11-10' AS friday, 2 as week_of_month
	UNION
	SELECT '2023-11-17' AS friday, 3 as week_of_month
	UNION
	SELECT '2023-11-24' AS friday, 4 as week_of_month
) 

SELECT week_of_month, membership, SUM(amount_spend) AS total_amount FROM (
	SELECT week_of_month, 'Premium' AS membership, friday, ISNULL(amount_spend, 0) AS amount_spend
	FROM Fridays
	LEFT JOIN (
		SELECT purchase_date, amount_spend, membership
		FROM Purchases p
		JOIN Users u ON p.user_id = u.user_id
		WHERE membership IN ('Premium', 'VIP')
	) AS t
	ON friday = purchase_date
	AND membership = 'Premium'
	
	UNION ALL
	
	SELECT week_of_month, 'VIP' AS membership, friday, ISNULL(amount_spend, 0) AS amount_spend
	FROM Fridays
	LEFT JOIN (
		SELECT purchase_date, amount_spend, membership
		FROM Purchases p
		JOIN Users u ON p.user_id = u.user_id
		WHERE membership IN ('Premium', 'VIP')
	) AS t
	ON friday = purchase_date
	AND membership = 'VIP'
) AS t
GROUP BY week_of_month, membership
ORDER BY week_of_month, membership