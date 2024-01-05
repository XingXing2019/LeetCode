select cast((day(purchase_date) - 1) / 7 + 1 as signed) as week_of_month, purchase_date, sum(amount_spend) as total_amount
from Purchases
where purchase_date between '2023-11-01' and '2023-11-30'
and dayofweek(purchase_date) = 6
group by purchase_date
order by purchase_date