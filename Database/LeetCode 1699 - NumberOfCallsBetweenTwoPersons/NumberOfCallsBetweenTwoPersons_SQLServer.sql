with cte as (
select case when from_id > to_id then to_id else from_id end as fromId, 
case when from_id > to_id then from_id else to_id end as toId, duration
from Calls)
select fromId as person1, toId as person2, count(toId) as call_count, sum(duration) as total_duration 
from cte group by fromId, toId;