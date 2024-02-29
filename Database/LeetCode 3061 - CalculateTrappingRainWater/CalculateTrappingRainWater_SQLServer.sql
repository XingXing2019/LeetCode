WITH LeftMax AS (
	SELECT id, MAX(height) OVER(ORDER BY id) AS left_max FROM Heights
),

RightMax AS (
	SELECT id, MAX(height) OVER(ORDER BY id DESC) AS right_max FROM Heights
),

MinHeight AS (
	SELECT l.id, IIF(left_max < right_max, left_max, right_max) AS min_height
	FROM LeftMax l JOIN RightMax r ON l.id = r.id
)

SELECT SUM(IIF(min_height > height, min_height - height, 0)) AS total_trapped_water
FROM Heights h
JOIN MinHeight m ON m.id = h.id