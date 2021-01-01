select extra as report_reason, count(distinct post_id) as report_count
from actions where action_date = DATEADD(day, -1, '2019-07-05') and action = 'report' and extra is not null 
group by extra;

