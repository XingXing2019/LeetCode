select driver_id, ifnull(cnt, 0) as cnt from 
(select distinct driver_id from rides) as d
left join (
	select passenger_id, count(distinct ride_id) as cnt
	from rides
	group by passenger_id
) as p
on d.driver_id = p.passenger_id