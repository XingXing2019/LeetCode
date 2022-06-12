select * from (
	select count(*) as weekend_cnt
    from tasks where dayofweek(submit_date) in (1, 7)
) as Weekend
join (
	select count(*) as working_cnt
    from tasks where dayofweek(submit_date) not in (1, 7)
) as WorkingDays
ON 1 = 1