with install as (
	select player_id, min(event_date) as install_dt
	from activity
	group by player_id
)

select install_dt, count(install_dt) as installs,
round(count(event_date) / count(install_dt), 2) as Day1_retention
from install i
left join activity a
on i.player_id = a.player_id
and datediff(install_dt, event_date) = -1
group by install_dt