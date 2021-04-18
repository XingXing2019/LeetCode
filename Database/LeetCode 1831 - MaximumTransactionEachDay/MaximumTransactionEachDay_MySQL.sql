select transaction_id from 
transactions t1 join 
(select date(day) as day, max(amount) as max from transactions group by date(day)) as t2
on date(t1.day) = t2.day and t1.amount = t2.max
order by transaction_id