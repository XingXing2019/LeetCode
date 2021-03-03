WITH recursion AS (
	SELECT number, frequency FROM numbers
	UNION ALL
	SELECT number, frequency - 1 FROM recursion WHERE frequency > 1
)

SELECT DISTINCT PERCENTILE_CONT(0.5) WITHIN GROUP(ORDER BY number) OVER() AS median FROM recursion
