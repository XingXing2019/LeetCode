with SessionRank as (
	select *, rank() over(partition by user_id order by session_start) as session_rank
    	from Sessions
)

select user_id, count(session_id) as sessions_count
from Sessions
where user_id in (
	select user_id from SessionRank
	where session_rank = 1
	and session_type = 'Viewer'
)
and session_type = 'Streamer'
group by user_id
order by count(session_id) desc, user_id desc
