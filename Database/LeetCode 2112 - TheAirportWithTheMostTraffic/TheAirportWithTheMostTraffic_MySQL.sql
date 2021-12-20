with airport_flights as (
	select airport_id, sum(flights_count) as flights from (
		select departure_airport as airport_id, flights_count from flights
		union all
		select arrival_airport as airport_id, flights_count from flights
	) as flights
    group by airport_id
)

select airport_id 
from airport_flights
where flights = (select max(flights) from airport_flights)