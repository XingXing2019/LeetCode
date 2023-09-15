select 
	s1.user_id as user_id,
    s3.steps_date as steps_date,
	round((s1.steps_count + s2.steps_count + s3.steps_count) / 3, 2) as rolling_average
from Steps s1
join Steps s2
on s1.user_id = s2.user_id and datediff(s2.steps_date, s1.steps_date) = 1
join Steps s3
on s2.user_id = s3.user_id and datediff(s3.steps_date, s2.steps_date) = 1
order by user_id, steps_date