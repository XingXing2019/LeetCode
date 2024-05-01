select first_name, type, sec_to_time(duration) as duration_formatted
from (
	select *, rank() over(partition by type order by duration desc) as duration_rank
	from Calls
) as t 
join Contacts on id = contact_id
where duration_rank <= 3
order by type, duration desc