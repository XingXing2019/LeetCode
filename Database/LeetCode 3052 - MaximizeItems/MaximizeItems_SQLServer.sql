WITH CombinationSize AS (
	SELECT item_type, MAX(combinations) AS combination_size, COUNT(combinations) AS count
	FROM (
		SELECT item_type, SUM(square_footage) OVER(PARTITION BY item_type ORDER BY square_footage) AS combinations
		FROM Inventory
	) AS t
	GROUP BY item_type
),

PrimeSize AS (
	SELECT item_type, CONVERT(INT, 500000 / combination_size) * combination_size AS prime_size 
	FROM CombinationSize WHERE item_type = 'prime_eligible'
)

SELECT * FROM (
	SELECT c.item_type, CONVERT(INT, (500000 - prime_size) / combination_size) * count AS item_count
	FROM CombinationSize c
	CROSS JOIN PrimeSize
	WHERE c.item_type = 'not_prime'
	UNION
	SELECT c.item_type, CONVERT(INT, 500000 / combination_size) * count AS item_count
	FROM CombinationSize c
	CROSS JOIN PrimeSize
	WHERE c.item_type = 'prime_eligible'
) AS t
ORDER BY item_count DESC