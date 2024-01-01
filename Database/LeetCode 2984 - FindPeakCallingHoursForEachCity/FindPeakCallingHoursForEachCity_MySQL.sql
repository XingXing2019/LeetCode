with PeakCalls as (
	select city, hour(call_time) as peak_calling_hour, count(*) as number_of_calls
	from Calls group by city, hour(call_time)
)

select city, peak_calling_hour, number_of_calls
from (
	select *, rank() over(partition by city order by number_of_calls desc) as call_rank
	from PeakCalls
) as t
where call_rank = 1
order by peak_calling_hour desc, city desc
