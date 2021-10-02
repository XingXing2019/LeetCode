WITH month_2020 AS (
	SELECT 1 AS month, 3 AS end_month
	UNION ALL
	SELECT month + 1 AS month, end_month + 1 AS end_month
	FROM month_2020
	WHERE end_month < 12
),
rides_2020 AS (
	SELECT ar.*, r.requested_at
	FROM Rides r JOIN AcceptedRides ar
	ON r.ride_id = ar.ride_id
	WHERE requested_at BETWEEN '2020-01-01' AND '2020-12-31'
)

SELECT m.month, 
ISNULL(ROUND(CONVERT(FLOAT, SUM(ride_distance)) / 3, 2), 0) AS average_ride_distance,
ISNULL(ROUND(CONVERT(FLOAT, SUM(ride_duration)) / 3, 2), 0) AS average_ride_duration
FROM month_2020 m
LEFT JOIN rides_2020 r
ON DATEPART(MONTH, r.requested_at) BETWEEN m.month AND m.end_month
GROUP BY m.month
