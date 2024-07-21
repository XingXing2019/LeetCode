select 
	transaction_date,
    sum(if(amount % 2 <> 0, amount, 0)) as odd_sum,
    sum(if(amount % 2 = 0, amount, 0)) as even_sum
from Transactions
group by transaction_date
order by transaction_date