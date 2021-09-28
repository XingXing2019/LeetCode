with recursive month_2020 as (
	select 1 as month
    union all
    select month + 1 as month
    from month_2020
    where month < 12
),
driver_2020 as (
	select month, sum(drivers) over(order by month) as total_drivers from (
		select m.month, count(distinct driver_id) as drivers
		from month_2020 m left join (
			select driver_id, case when join_date < '2020-01-01' then 1 else month(join_date) end as month
			from drivers
			where join_date < '2021-01-01'
			) as t on m.month = t.month
		group by m.month
	) as t
),
rides_2020 as (
	select m.month, count(distinct t.driver_id) as rides
	from month_2020 m left join (
		select a.ride_id, r.requested_at, a.driver_id
		from acceptedrides a 
		join rides r on a.ride_id = r.ride_id
		where requested_at between '2020-01-01' and '2020-12-31'
	) as t on m.month = month(t.requested_at)
	group by m.month
)

select d.month, if(total_drivers = 0, 0, round(rides / total_drivers * 100, 2)) as working_percentage
from driver_2020 d join rides_2020 r
on d.month = r.month