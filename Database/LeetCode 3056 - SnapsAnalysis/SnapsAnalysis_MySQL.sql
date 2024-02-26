with SendTime as (
	select age_bucket, sum(time_spent) as time_spent 
    from Activities at
    join Age ag on at.user_id = ag.user_id
    where activity_type = 'send'
    group by age_bucket, activity_type
),

OpenTime as (
	select age_bucket, sum(time_spent) as time_spent 
    from Activities at
    join Age ag on at.user_id = ag.user_id
    where activity_type = 'open'
    group by age_bucket, activity_type
)

select distinct
	a.age_bucket,
    round(ifnull(s.time_spent, 0) / (ifnull(s.time_spent, 0) + ifnull(o.time_spent, 0)) * 100, 2) as send_perc,
    round(ifnull(o.time_spent, 0) / (ifnull(s.time_spent, 0) + ifnull(o.time_spent, 0)) * 100, 2) as open_perc
from Age a
left join SendTime s on a.age_bucket = s.age_bucket
left join OpenTime o on a.age_bucket = o.age_bucket