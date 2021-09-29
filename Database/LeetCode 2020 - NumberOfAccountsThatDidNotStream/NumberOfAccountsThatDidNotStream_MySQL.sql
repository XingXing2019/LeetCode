select count(distinct s1.account_id) as accounts_count
from Subscriptions s1 join
Streams s2 on s1.account_id = s2.account_id
where (s1.start_date between '2021-01-01' and '2021-12-31'
or s1.end_date between '2021-01-01' and '2021-12-31')
and s2.stream_date not between '2021-01-01' and '2021-12-31'