WITH TriangleSize AS (
	SELECT 
		A, B, C, A + B + C AS sum,
		CASE 
			WHEN A <= B AND A <= C THEN A
			WHEN B <= A AND B <= C THEN B
			ELSE C
		END AS min,
		CASE
			WHEN A >= B AND A >= C THEN A
			WHEN B >= A AND B >= C THEN B
			ELSE C
		END AS max
	FROM Triangles
)

SELECT 
	CASE
		WHEN sum - max <= max THEN 'Not A Triangle'
		WHEN A = B AND B = C THEN 'Equilateral'
		WHEN A = B OR A = C OR B = C THEN 'Isosceles'
		ELSE 'Scalene'
	END AS triangle_type
FROM TriangleSize