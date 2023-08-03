with OrderRank as (
	select passenger_id, flight_id,
    rank() over(partition by flight_id order by booking_time) as order_rank
    from Passengers
)

select passenger_id,
case
	when order_rank <= capacity then 'Confirmed'
    else 'Waitlist'
end as Status
from OrderRank o 
join Flights f on o.flight_id = f.flight_id
order by passenger_id