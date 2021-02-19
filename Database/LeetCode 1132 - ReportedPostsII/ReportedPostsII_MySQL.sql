with spam as (select * from actions where extra = 'spam'),
removeRate as (select count(distinct r.post_id) / count(distinct s.post_id) as rate
from spam s left join removals r on s.post_id = r.post_id and s.action_date < r.remove_date
group by s.action_date)
select round(avg(rate) * 100, 2) as average_daily_percent from removeRate