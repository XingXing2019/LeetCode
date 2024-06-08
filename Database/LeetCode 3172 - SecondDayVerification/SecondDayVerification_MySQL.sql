select user_id
from emails e
left join texts t on e.email_id = t.email_id
and timestampdiff(day, date(e.signup_date), date(t.action_date)) = 1
where signup_action = 'Verified'
order by user_id