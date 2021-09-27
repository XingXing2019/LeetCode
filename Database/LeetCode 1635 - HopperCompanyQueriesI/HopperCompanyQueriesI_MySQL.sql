with recursive month_2020 as (
	select 1 as month
	union all
	select month + 1 as month
	from month_2020
	where month < 12
),
driver_2020 as (
	select m.month, count(driver_id) as drivers
	from month_2020 m left join (
		select driver_id, case when join_date < '2020-01-01' then 1 else month(join_date) end as month 
		from drivers
		where join_date < '2021-01-01'
	) as t on m.month = t.month
	group by m.month
),
active_drivers as (
	select month, sum(drivers) over(order by month) as active_drivers
    from driver_2020
),
accepted_rides as (
	select m.month, count(ride_id) as accepted_rides 
	from month_2020 m left join (
		select a.ride_id, r.requested_at from AcceptedRides a
		join Rides r on a.ride_id = r.ride_id
		where requested_at between '2020-01-01' and '2020-12-31'
	) as t on m.month = month(t.requested_at)
	group by m.month
)
select ar.month, ad.active_drivers, ar.accepted_rides
from accepted_rides ar
join active_drivers ad 
on ar.month = ad.month