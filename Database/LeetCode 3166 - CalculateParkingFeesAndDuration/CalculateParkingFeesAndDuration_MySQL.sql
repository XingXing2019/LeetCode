with ParkingInfo as (
	select lot_id, car_id, sum(timestampdiff(minute, entry_time, exit_time)) as duration, sum(fee_paid) as fee_paid
    from ParkingTransactions
    group by lot_id, car_id
)

select t1.car_id, total_fee_paid, avg_hourly_fee, lot_id as most_time_lot
from (
	select *, rank() over(partition by car_id order by duration desc) as duration_rank
	from ParkingInfo
) as t1
join (
	select car_id, sum(fee_paid) as total_fee_paid, round(sum(fee_paid) / (sum(duration) / 60), 2) as avg_hourly_fee
	from ParkingInfo
	group by car_id
) as t2 on t1.car_id = t2.car_id
where duration_rank = 1
order by t1.car_id