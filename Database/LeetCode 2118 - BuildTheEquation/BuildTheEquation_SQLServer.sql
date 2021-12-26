WITH Equations AS (
	SELECT power,
	CASE WHEN factor > 0 THEN
		CASE WHEN power = 0 THEN CONCAT('+', factor)
		WHEN power = 1 THEN CONCAT('+', factor, 'X')
		ELSE CONCAT('+', factor, 'X^', power) END
	ELSE 
		CASE WHEN power = 0 THEN CONCAT('', factor)
		WHEN power = 1 THEN CONCAT(factor, 'X')
		ELSE CONCAT(factor, 'X^', power) END 
	END AS equations
	FROM Terms	
)

SELECT STRING_AGG(equations, '') 
WITHIN GROUP (ORDER BY power DESC) + '=0' AS equation 
FROM Equations