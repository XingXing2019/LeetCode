WITH drivers AS (
	SELECT DISTINCT driver_id FROM Rides
)

SELECT driver_id, ISNULL(cnt, 0) AS cnt FROM 
drivers d LEFT JOIN (
	SELECT passenger_id, COUNT(DISTINCT ride_id) AS cnt
	FROM Rides 
	GROUP BY passenger_id
) AS t
ON d.driver_id = t.passenger_id