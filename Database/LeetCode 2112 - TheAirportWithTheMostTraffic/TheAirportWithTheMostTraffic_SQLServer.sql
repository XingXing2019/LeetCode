WITH airport_flights AS (
	SELECT airport_id, SUM(flights_count) AS flights FROM (
		SELECT departure_airport AS airport_id, flights_count FROM flights
		UNION ALL
		SELECT arrival_airport AS airport_id, flights_count FROM flights
	) AS flights
	GROUP BY airport_id	
)

SELECT airport_id FROM airport_flights
WHERE flights = (SELECT MAX(flights) FROM airport_flights)