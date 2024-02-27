select distinct s1.user_id
from Sessions s1
join Sessions s2 on s1.user_id = s2.user_id
where s1.session_id <> s2.session_id
and s1.session_type = s2.session_type
and timestampdiff(hour, s1.session_end, s2.session_start) >= -12
and timestampdiff(hour, s1.session_end, s2.session_start) <= 12
order by s1.user_id