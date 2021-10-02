with recursive month_2020 as (
	select 1 as month, 3 as end_month
	union all
	select month + 1 as month, end_month + 1 as end_month
	from month_2020
	where end_month < 12
),
rides_2020 as (
	select ar.*, r.requested_at
    from rides r join acceptedrides ar
    on r.ride_id = ar.ride_id
    where r.requested_at between '2020-01-01' and '2020-12-31'
)

select m.month, 
ifnull(round(sum(r.ride_distance) / 3, 2), 0) as average_ride_distance,
ifnull(round(sum(r.ride_duration) / 3, 2), 0) as average_ride_duration
from month_2020 m
left join rides_2020 r
on month(r.requested_at) between m.month and m.end_month
group by m.month