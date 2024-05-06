WITH ConsectiveSeats AS (
	SELECT MIN(seat_id) AS first_seat_id, MAX(seat_id) AS last_seat_id, MAX(seat_id) - MIN(seat_id) + 1 AS consecutive_seats_len 
	FROM (
		SELECT *, seat_id - ROW_NUMBER() OVER(PARTITION BY free ORDER BY seat_id) AS free_lag
		FROM Cinema
	) AS t
	WHERE free = '1'
	GROUP BY free_lag
)

SELECT * 
FROM ConsectiveSeats
WHERE consecutive_seats_len = (SELECT MAX(consecutive_seats_len) FROM ConsectiveSeats)