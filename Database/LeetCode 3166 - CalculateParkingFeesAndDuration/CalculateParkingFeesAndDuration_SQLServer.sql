WITH ParkingInfo AS (
	SELECT lot_id, car_id, SUM(DATEDIFF(MINUTE, entry_time, exit_time)) AS duration, SUM(fee_paid) AS fee_paid
	FROM ParkingTransactions
	GROUP BY lot_id, car_id
)

SELECT t1.car_id, total_fee_paid, avg_hourly_fee, lot_id AS most_time_lot  
FROM (
	SELECT *, RANK() OVER(PARTITION BY car_id ORDER BY duration DESC) AS duration_rank
	FROM ParkingInfo
) AS t1 
JOIN (
	SELECT car_id, SUM(fee_paid) AS total_fee_paid, ROUND(SUM(fee_paid) / (SUM(duration) / 60.0), 2) AS avg_hourly_fee
	FROM ParkingInfo
	GROUP BY car_id
) AS t2 ON t1.car_id = t2.car_id
WHERE duration_rank = 1
ORDER BY t1.car_id