SELECT DISTINCT MIN(
ROUND(
	SQRT(
		ABS(CONVERT(decimal, p1.x) - p2.x) * ABS(CONVERT(decimal, p1.x) - p2.x) + 
		ABS(CONVERT(decimal, p1.y) - p2.y) * ABS(CONVERT(decimal, p1.y) - p2.y)
	), 2)
) AS shortest FROM 
point_2d p1 CROSS JOIN point_2d p2
WHERE ABS(p1.x - p2.x) + ABS(p1.y - p2.y) <> 0