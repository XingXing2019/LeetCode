SELECT p1.id AS p1, p2.id AS p2, ABS(p1.x_value - p2.x_value) * ABS(p1.y_value - p2.y_value) AS area
FROM points p1 LEFT JOIN points p2 ON p2.id > p1.id
WHERE p1.x_value <> p2.x_value AND p1.y_value <> p2.y_value
ORDER BY area DESC, p1, p2
