select login_date, count(*) as user_count from (
	select user_id, min(activity_date) as login_date from traffic where activity = 'login' group by user_id	) as t 
where t.login_date >= DATEADD(day, -90, '2019-06-30') 
group by t.login_date