with incomes as (select year(day) + month(day) / 10 as date, account_id, sum(amount) as incomes
from transactions where type = 'Creditor'
group by year(day) + month(day) / 10, account_id),
cte as (select date, a.account_id, incomes from incomes i left join accounts a on i.account_id = a.account_id where incomes > max_income)

select distinct c1.account_id from cte c1 inner join cte c2 on c1.account_id = c2.account_id and c2.date - c1.date = 0.1;
