WITH Bus_Passenger AS (
	SELECT b.bus_id, b.arrival_time, COUNT(DISTINCT p.passenger_id) AS passengers_cnt
	FROM Buses b 
	LEFT JOIN Passengers p 
	ON b.arrival_time >= p.arrival_time
	GROUP BY b.bus_id, b.arrival_time
),

Passenger_Count AS (
	SELECT RANK() OVER(PARTITION BY b1.bus_id ORDER BY b2.arrival_time DESC) AS rank,
	b1.bus_id, b1.passengers_cnt - ISNULL(b2.passengers_cnt, 0) AS passengers_cnt
	FROM Bus_Passenger b1
	LEFT JOIN Bus_Passenger b2
	ON b1.arrival_time > b2.arrival_time
)

SELECT bus_id, passengers_cnt
FROM Passenger_Count
WHERE rank = 1
ORDER BY bus_id