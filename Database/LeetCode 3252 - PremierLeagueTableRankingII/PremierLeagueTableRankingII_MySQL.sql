with Position as (
	select *, rank() over(order by t.points desc) as position
	from (
		select team_name, wins * 3 + draws as points
		from Teamstats
	) as t
)

select *,
case
	when position <= ceiling((select count(*) from Position) * 0.33) then 'Tier 1'
    when position > ceiling((select count(*) from Position) * 0.66) then 'Tier 3'
    else 'Tier 2'
end as tier
from Position
order by points desc, team_name