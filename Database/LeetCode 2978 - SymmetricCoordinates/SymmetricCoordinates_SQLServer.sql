WITH Rows AS (
	SELECT *, ROW_NUMBER() OVER(ORDER BY X, Y) AS RowNumber
	FROM Coordinates
)

SELECT DISTINCT r1.X, r1.Y
FROM Rows r1
JOIN Rows r2 ON r1.X = r2.Y 
AND r1.Y = r2.X
WHERE r1.RowNumber <> r2.RowNumber
AND r1.X <= r1.Y
ORDER BY r1.X, r1.Y