-- Join 
select a.player_id, a.device_id 
from Activity a join 
(select player_id, min(event_date) as min 
from Activity group by player_id) t
on a.player_id = t.player_id
where event_date = min;

-- partition by 
select t.player_id, t.device_id from (
select *, row_number() over(partition by player_id order by event_date) as rank from Activity) as t
where t.rank = 1;