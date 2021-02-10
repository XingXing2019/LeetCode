with cte as
(
    select host_team as team_id, case when host_goals > guest_goals then 3 when host_goals = guest_goals then 1 else 0 end as points from Matches
    union all
    select guest_team as team_id, case when guest_goals > host_goals then 3 when guest_goals = host_goals then 1 else 0 end as points from Matches
)
select t.team_id, t.team_name, coalesce(sum(c.points), 0) as num_points from Teams as t
left join cte as c on t.team_id = c.team_id group by t.team_id, t.team_name
order by coalesce(sum(c.points), 0) desc, t.team_id asc;