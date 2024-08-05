select * from (
	select team_id, team_name, t1.points, rank() over(order by t1.points desc) as position  
	from (
		select team_id, team_name, (wins * 3 + draws) as points 
		from TeamStats
	) as t1
) as t2
order by position, team_name

