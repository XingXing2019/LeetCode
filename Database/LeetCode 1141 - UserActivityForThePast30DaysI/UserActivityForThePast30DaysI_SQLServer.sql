select activity_date as day, count(distinct user_id) as active_users
from activity where activity_date between DATEADD(day, -30, '2019-07-28') and '2019-07-27'
group by activity_date;