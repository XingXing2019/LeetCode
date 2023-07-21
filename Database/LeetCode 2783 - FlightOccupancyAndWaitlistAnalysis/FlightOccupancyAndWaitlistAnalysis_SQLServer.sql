SELECT
	f.flight_id, 
	IIF(t.flight_id IS NULL, 0, IIF(f.capacity > t.count, count, f.capacity)) AS booked_cnt,
	IIF(t.flight_id IS NULL, 0, IIF(t.count - f.capacity > 0, t.count - f.capacity, 0)) AS waitlist_cnt
FROM Flights f LEFT JOIN (
	SELECT flight_id, COUNT(passenger_id) AS count
	FROM Passengers
	GROUP BY flight_id
) AS t
ON f.flight_id = t.flight_id
ORDER BY f.flight_id