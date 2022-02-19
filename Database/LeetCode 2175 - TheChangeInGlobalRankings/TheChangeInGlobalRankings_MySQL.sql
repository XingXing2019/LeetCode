with old_rank as (
	select *, rank() over(order by points desc, name) as old_rank from TeamPoints
),

new_rank as (
	select t.*, rank() over(order by t.points + ifnull(p.points_change, 0) desc, name) as new_rank
	from TeamPoints t
	left join PointsChange p
	on t.team_id = p.team_id
)

select o.team_id, o.name, (cast(o.old_rank as signed) - cast(n.new_rank as signed)) as rank_diff
from old_rank o 
join new_rank n on o.team_id = n.team_id