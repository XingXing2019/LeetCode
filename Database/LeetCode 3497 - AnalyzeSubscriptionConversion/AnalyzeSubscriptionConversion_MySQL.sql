with Activities as (
	select user_id, activity_type, sum(activity_duration) / count(*) as avg_duration
    from UserActivity
    where activity_type in ('free_trial', 'paid')
    group by user_id, activity_type
)

select a1.user_id, round(a1.avg_duration, 2) as trial_avg_duration, round(a2.avg_duration, 2) as paid_avg_duration
from Activities a1
left join Activities a2 on a1.user_id = a2.user_id
where a1.activity_type = 'free_trial'
and a2.activity_type = 'paid'