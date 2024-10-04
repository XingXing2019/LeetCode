SELECT fuel_type, driver_id, rating, distance
FROM (
	SELECT *, RANK() OVER(PARTITION BY fuel_type ORDER BY rating DESC, distance DESC, accidents) AS rank
	FROM (
		SELECT 
			v.fuel_type,
			d.driver_id, 
			ROUND(AVG(t.rating * 1.0), 2) AS rating, 
			SUM(t.distance) AS distance,
			SUM(d.accidents) AS accidents 
		FROM Drivers d
		JOIN Vehicles v ON v.driver_id = d.driver_id
		JOIN Trips t ON t.vehicle_id = v.vehicle_id
		GROUP BY d.driver_id, v.fuel_type 
	) AS t
) AS t
WHERE rank = 1
ORDER BY fuel_type