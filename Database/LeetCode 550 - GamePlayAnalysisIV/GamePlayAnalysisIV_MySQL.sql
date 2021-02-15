with cte1 as (select count(distinct player_id) as count from (
select *, min(event_date) over(partition by player_id order by event_date) as firstLogin from activity) as t
where datediff(event_date, firstLogin) = 1),
cte2 as (select count(distinct player_id) from activity)
select round((select * from cte1) / (select * from cte2), 2) as fraction
