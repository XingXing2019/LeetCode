select fuel_type, driver_id, rating, distance 
from (
	select *, rank() over(partition by fuel_type order by rating desc, distance desc, accidents) as ranking
	from (
		select 
			d.driver_id, 
			v.fuel_type, 
			round(avg(t.rating), 2) as rating, 
			sum(t.distance) as distance, 
			sum(d.accidents) as accidents
		from Drivers d
		join Vehicles v on v.driver_id = d.driver_id
		join Trips t on t.vehicle_id = v.vehicle_id
		group by d.driver_id, v.fuel_type
	) as t
) as t
where ranking = 1
