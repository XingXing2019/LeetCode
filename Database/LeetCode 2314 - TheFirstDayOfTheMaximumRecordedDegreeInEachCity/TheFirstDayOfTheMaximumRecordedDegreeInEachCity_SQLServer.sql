WITH MaxTemperature AS (
	SELECT city_id, MAX(degree) AS max_degree
	FROM Weather
	GROUP BY city_id
)

SELECT city_id, MIN(day) AS day, degree FROM (
	SELECT mt.city_id, w.day, w.degree 
	FROM MaxTemperature mt
	LEFT JOIN Weather w
	ON mt.city_id = w.city_id
	AND mt.max_degree = w.degree
) AS t
GROUP BY city_id, degree
ORDER BY city_id;

WITH MaxTemperature AS (
	SELECT city_id, MAX(degree) AS max_degree
	FROM Weather
	GROUP BY city_id
)

SELECT mt.city_id, day, degree
FROM MaxTemperature mt
CROSS APPLY (
	SELECT TOP 1 * FROM Weather w
	WHERE mt.city_id = w.city_id
	AND mt.max_degree = w.degree
	ORDER BY w.day
) AS t
ORDER BY city_id