select t.user_id, max(t.window) as biggest_window from(
	select r1.user_id, DATEDIFF(day, r1.visit_date, isnull(r2.visit_date, '2021-01-01')) as window 
	from (select *, rank() over(partition by user_id order by visit_date) as rank from UserVisits) as r1 
	left join (select *, rank() over(partition by user_id order by visit_date) as rank 
	from UserVisits) as r2 
	on r1.rank = r2.rank - 1 and r1.user_id = r2.user_id
) as t group by t.user_id
