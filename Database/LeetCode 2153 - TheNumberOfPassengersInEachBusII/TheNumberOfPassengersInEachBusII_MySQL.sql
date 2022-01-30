with recursive bus as (
	select *, rank() over(order by arrival_time) as order_id from buses
),

bus_passenger as (
	select p.passenger_id, min(b.arrival_time) bus_arrival
	from bus b
	left join passengers p
	on b.arrival_time >= p.arrival_time
	group by p.passenger_id
),

passenger_count as (
	select b.bus_id, order_id, b.capacity, count(bp.passenger_id) as passenger_count
    from bus b
    left join bus_passenger bp
    on b.arrival_time = bp.bus_arrival
    group by b.bus_id, b.capacity
),

cte as (
	select 
		bus_id,
		order_id,
		if(capacity >= passenger_count, passenger_count, capacity) as number,
		if(capacity < passenger_count, passenger_count - capacity, 0) as leftover
	from passenger_count
	where order_id = 1
	union all
	select 
		p.bus_id,
		p.order_id,
		if(p.capacity >= p.passenger_count + leftover, p.passenger_count + leftover, p.capacity) as number,
		if(p.capacity < p.passenger_count + leftover, p.passenger_count + leftover - p.capacity, 0) as leftover
	from passenger_count p
	join cte c
	on p.order_id = c.order_id + 1
)

select bus_id, number as passengers_cnt from cte
order by bus_id

