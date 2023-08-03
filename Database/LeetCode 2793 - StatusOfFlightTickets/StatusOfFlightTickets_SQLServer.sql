SELECT passenger_id, 
CASE
	WHEN t.rank <= f.capacity THEN 'Confirmed'
	ELSE 'Waitlist'
END AS Status
FROM (
	SELECT passenger_id, flight_id, 
	RANK() OVER(PARTITION BY flight_id ORDER BY booking_time) AS rank
	FROM Passengers
) AS t
JOIN Flights f ON t.flight_id = f.flight_id
ORDER BY passenger_id