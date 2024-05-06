with ConsecutiveSeats as (
	select min(seat_id) as first_seat_id, max(seat_id) as last_seat_id, max(seat_id) - min(seat_id) + 1 as consecutive_seats_len
	from (
		select *, seat_id - rank() over(partition by free order by seat_id) as free_lag
		from Cinema
		where free
	) as t
	group by free_lag
)

select * from ConsecutiveSeats
where consecutive_seats_len = (select max(consecutive_seats_len) from ConsecutiveSeats)