WITH month_2020 AS (
	SELECT 1 AS month
	UNION ALL
	SELECT month + 1 AS month
	FROM month_2020
	WHERE month < 12
),
driver_2020 AS (
	SELECT month, SUM(drivers) OVER(ORDER BY month) AS total_drivers FROM (
		SELECT m.month, COUNT(driver_id) AS drivers
		FROM month_2020 m LEFT JOIN (
			SELECT *, CASE WHEN join_date < '2020-01-01' THEN 1 ELSE DATEPART(MONTH, join_date) END AS month
			FROM Drivers
			WHERE join_date < '2021-01-01'
		) AS t1 ON m.month = t1.month
		GROUP BY m.month
	) AS t2	
),
rides_2020 AS (
	SELECT m.month, COUNT(DISTINCT driver_id) AS rides FROM month_2020 m LEFT JOIN (
		SELECT a.ride_id, r.requested_at, a.driver_id
		FROM AcceptedRides a
		JOIN Rides r ON a.ride_id = r.ride_id
		WHERE r.requested_at BETWEEN '2020-01-01' AND '2020-12-31'		
	) AS t ON m.month = DATEPART(MONTH, requested_at)
	GROUP BY m.month
)

SELECT d.month, IIF(total_drivers = 0, 0, ROUND(CONVERT(FLOAT, rides) / total_drivers * 100, 2)) AS working_percentage
FROM driver_2020 d JOIN rides_2020 r 
ON d.month = r.month