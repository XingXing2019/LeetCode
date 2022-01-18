with bus_passenger as (
	select b.bus_id, b.arrival_time, count(distinct p.passenger_id) as passengers_cnt
	from buses b
	left join passengers p
	on b.arrival_time >= p.arrival_time
	group by b.bus_id, b.arrival_time
),

passenger_count as (
	select rank() over(partition by b1.bus_id order by b2.arrival_time desc) as bus_rank,
	b1.bus_id, b1.passengers_cnt - ifnull(b2.passengers_cnt, 0) as passengers_cnt
	from bus_passenger b1
	left join bus_passenger b2
	on b1.arrival_time > b2.arrival_time
)

select bus_id, passengers_cnt
from passenger_count
where bus_rank = 1
order by bus_id