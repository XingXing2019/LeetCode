with cte as (
select user_id, count(distinct session_id) as sessions from activity where activity_date between DATEADD(day, -30, '2019-07-28') and '2019-07-27'
group by user_id)
select round(isnull(avg(convert(decimal, cte.sessions)), 0) , 2) as average_sessions_per_user from cte
