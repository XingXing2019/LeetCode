select * 
from (
	select state, group_concat(city order by city separator ', ') as cities, sum(
		case
			when left(state, 1) = left(city, 1) then 1
			else 0
		end
	) as matching_letter_count 
	from cities
	group by state
    having count(*) >= 3
) as t
where matching_letter_count > 0
order by matching_letter_count desc, state