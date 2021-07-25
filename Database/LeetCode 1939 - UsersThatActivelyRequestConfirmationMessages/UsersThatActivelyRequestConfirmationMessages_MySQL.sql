select distinct c2.user_id
from confirmations c1 join confirmations c2 
on c1.user_id = c2.user_id
and c1.time_stamp < c2.time_stamp
and timestampdiff(second, c1.time_stamp, c2.time_stamp) <= 24 * 60 * 60