with scores as (
	select t1.team_name, substr(time_stamp, 1, 2) * 60 + substr(time_stamp, 4, 2) as time,
    case
		when t1.team_name = t2.team_name then 1
        else -1
	end as score
    from Passes
    join Teams t1 on t1.player_id = pass_from
    join Teams t2 on t2.player_id = pass_to
)

select team_name, half_number, sum(score) as dominance from (
	select team_name, 1 as half_number, score from scores
	where time <= 45 * 60
	union all
	select team_name, 2 as half_number, score from scores
	where time > 45 * 60
) as t
group by team_name, half_number
order by team_name, half_number