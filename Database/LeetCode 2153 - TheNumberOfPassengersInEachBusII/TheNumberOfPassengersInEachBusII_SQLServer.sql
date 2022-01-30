WITH Bus AS (
	SELECT 
		bus_id,
		RANK() OVER(ORDER BY arrival_time) AS order_id, 
		capacity, arrival_time 
	FROM Buses
),

Bus_Passenger AS (
	SELECT p.passenger_id, MIN(b.arrival_time) AS bus_arrival
	FROM Bus b
	LEFT JOIN Passengers p
	ON b.arrival_time >= p.arrival_time
	GROUP BY p.passenger_id
),

Passenger_Count AS (
	SELECT bus_id, order_id, b.arrival_time, b.capacity, COUNT(passenger_id) AS passenger_count
	FROM Bus b
	LEFT JOIN Bus_Passenger bp
	ON b.arrival_time = bp.bus_arrival
	GROUP BY bus_id, order_id, b.arrival_time, b.capacity
),
CTE AS (
	SELECT
		bus_id, 
		order_id,
		IIF(capacity >= passenger_count, passenger_count, capacity) AS number, 
		IIF(capacity < passenger_count, passenger_count - capacity, 0) AS leftover
	FROM Passenger_Count
	WHERE order_id = 1
	UNION ALL
	SELECT
		pc.bus_id, 
		pc.order_id,
		IIF(capacity >= passenger_count + leftover, passenger_count + leftover, capacity) AS number, 
		IIF(capacity < passenger_count + leftover, passenger_count + leftover - capacity, 0) AS leftover
	FROM Passenger_Count pc
	JOIN CTE c
	ON pc.order_id = c.order_id + 1
)

SELECT bus_id, number AS passengers_cnt FROM CTE
ORDER BY bus_id