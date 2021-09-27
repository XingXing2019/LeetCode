WITH month_2020 AS (
	SELECT 1 month
	UNION ALL
	SELECT month + 1 
	FROM month_2020 WHERE month < 12
),

driver_2020 AS (
	SELECT m.month, COUNT(driver_id) AS drivers
	FROM month_2020 m LEFT JOIN (
		SELECT *, CASE WHEN join_date < '2020-01-01' THEN 1 ELSE DATEPART(MONTH, join_date) END AS month 
		FROM Drivers
		WHERE join_date < '2021-01-01'
	) AS t ON m.month = t.month
	GROUP BY m.month
),

active_driver AS (
	SELECT month, SUM(drivers) OVER (ORDER BY month) AS active_drivers 
	FROM driver_2020
),

accepted_rides AS (
	SELECT m.month, COUNT(ride_id) AS accepted_rides
	FROM month_2020 m LEFT JOIN (
		SELECT r.ride_id, r.requested_at, a.driver_id FROM Rides r 
		JOIN AcceptedRides a
		ON r.ride_id = a.ride_id
		AND r.requested_at BETWEEN '2020-01-01' AND '2020-12-31'
	) AS t ON m.month = DATEPART(MONTH, requested_at)	
	GROUP BY month
)

SELECT ad.month, ad.active_drivers, ar.accepted_rides
FROM active_driver ad JOIN
accepted_rides ar ON ad.month = ar.month