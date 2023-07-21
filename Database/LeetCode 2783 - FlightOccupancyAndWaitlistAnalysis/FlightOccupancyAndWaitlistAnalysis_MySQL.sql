with Count as (
	select flight_id, count(passenger_id) as count
    from Passengers
    group by flight_id
)

select 
	f.flight_id,
    if(c.flight_id is null, 0, least(f.capacity, c.count)) as booked_cnt,
    if(c.flight_id is null, 0, greatest(0, c.count - f.capacity)) as waitlist_cnt
from Flights f
left join Count c on f.flight_id = c.flight_id
order by f.flight_id