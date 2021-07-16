select s.user_id, ifnull(t.rate, 0) as confirmation_rate
from signups s left join 
(select user_id, round(sum(if(action = 'confirmed', 1, 0)) / count(*), 2) as rate
from confirmations
group by user_id) t
on s.user_id = t.user_id