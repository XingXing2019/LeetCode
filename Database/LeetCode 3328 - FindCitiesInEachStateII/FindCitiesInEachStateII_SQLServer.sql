SELECT state, cities, matching_letter_count
FROM (
	SELECT state, STRING_AGG(city, ', ') WITHIN GROUP(ORDER BY city) AS cities, SUM(
		CASE
			WHEN LEFT(state, 1) = LEFT(city, 1) THEN 1
			ELSE 0
		END
	) AS matching_letter_count 
	FROM cities
	GROUP BY state
	HAVING COUNT(*) >= 3
) AS t
WHERE matching_letter_count > 0 
ORDER BY matching_letter_count DESC, state