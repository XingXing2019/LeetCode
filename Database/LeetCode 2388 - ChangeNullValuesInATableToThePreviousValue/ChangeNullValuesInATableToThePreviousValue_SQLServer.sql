WITH CoffeeShopRow AS (
	SELECT ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) AS num_row, *
	FROM CoffeeShop
),

LastRow AS (
	SELECT c1.num_row, MAX(c2.num_row) AS last_row
	FROM CoffeeShopRow c1
	LEFT JOIN (SELECT * FROM CoffeeShopRow WHERE drink IS NOT NULL) c2
	ON c1.num_row > c2.num_row
	GROUP BY c1.num_row
)

SELECT c1.id, ISNULL(c1.drink, c2.drink) AS drink
FROM CoffeeShopRow c1
JOIN LastRow l
ON c1.num_row = l.num_row
LEFT JOIN CoffeeShopRow c2
ON c2.num_row = l.last_row