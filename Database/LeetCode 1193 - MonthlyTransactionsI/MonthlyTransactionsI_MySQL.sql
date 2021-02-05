select left(trans_date, 7) as month, country, count(*) as trans_count,
sum(case state when 'approved' then 1 else 0 end) as approved_count,
sum(amount) as trans_total_amount,
sum(case state when 'approved' then amount else 0 end) as approved_total_amount 
from transactions group by country, left(trans_date, 7)