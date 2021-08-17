with all_calls as (
	select caller_id as caller_id, recipient_id as recipient_id, call_time from calls
	union all
	select recipient_id as caller_id, caller_id as recipient_id, call_time from calls
),
first_last_calls as (
	select caller_id, min(call_time) as first_call, max(call_time) as last_call
	from all_calls
	group by caller_id, left(call_time, 10)
),
first_call as (
	select a.caller_id, a.recipient_id from
	all_calls a join first_last_calls f
	on a.caller_id = f.caller_id 
	and a.call_time = f.first_call
),
last_call as (
	select a.caller_id, a.recipient_id from
	all_calls a join first_last_calls f
	on a.caller_id = f.caller_id 
	and a.call_time = f.last_call
)
select distinct f.caller_id as user_id 
from first_call f join last_call l
on f.caller_id = l.caller_id
and f.recipient_id = l.recipient_id

