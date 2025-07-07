WITH year_part AS (
	SELECT 
		driver_id, distance_km / fuel_consumed AS fuel_efficiency, 
		CASE
			WHEN DATEPART(MONTH, trip_date) < 7 THEN 1
			ELSE 2
		END AS year_part
	FROM trips
),

fuel_efficiency AS (
	SELECT driver_id, year_part, AVG(fuel_efficiency) AS avg_efficiency FROM year_part
	GROUP BY year_part, driver_id
)

SELECT 
	d.driver_id,
	driver_name,
	ROUND(first_half_avg, 2) AS first_half_avg, 
	ROUND(second_half_avg, 2) AS second_half_avg, 
	ROUND(efficiency_improvement, 2) AS efficiency_improvement
FROM (
	SELECT 
		f1.driver_id, 
		f1.avg_efficiency AS first_half_avg, 
		f2.avg_efficiency AS second_half_avg, 
		f2.avg_efficiency - f1.avg_efficiency AS efficiency_improvement
	FROM fuel_efficiency f1
	JOIN fuel_efficiency f2 
	ON f1.driver_id = f2.driver_id
	AND f1.year_part = f2.year_part - 1
) AS t
JOIN drivers d ON d.driver_id = t.driver_id
WHERE efficiency_improvement > 0
ORDER BY efficiency_improvement DESC, driver_name