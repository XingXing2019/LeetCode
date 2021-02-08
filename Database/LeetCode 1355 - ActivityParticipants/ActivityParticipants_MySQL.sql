with cte as (select count(activity) count, activity from friends group by activity)
select activity from cte where count <> (select max(count) from cte) and count <> (select min(count) from cte)

